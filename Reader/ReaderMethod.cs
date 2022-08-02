using System;
using System.Net;
using System.IO.Ports;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using System.Globalization;
using System.Threading;

namespace Reader
{
    public delegate void ReciveDataCallback(object sender, TransportDataEventArgs e);
    public delegate void SendDataCallback(object sender, byte[] data);
    public delegate void AnalyDataCallback(object sender, MessageTran msgTran);
    public delegate void ErrCallback(object sender, ErrorReceivedEventArgs e);

    public class ReaderMethod 
    {
        private ITalker italker;
        private SerialPort iSerialPort;
        private IBle ible;
        private ReaderType m_nType = ReaderType.Default;

        public ReciveDataCallback ReceiveCallback;
        public SendDataCallback SendCallback;
        public AnalyDataCallback AnalyCallback;
        public ErrCallback ErrCallback;

        //Record unprocessed received data, mainly considering receiving data segmentation
        byte[] m_btAryBuffer = new byte[4096 * 10];
        //Record the effective length of the unprocessed data
        int m_nLenth = 0;

        public event EventHandler<TransportDataEventArgs> EvRecvData;
        public event EventHandler<ErrorReceivedEventArgs> EvException;
        protected void OnSerialTransport(bool tx, byte[] data)
        {
            MessageReceived(this.iSerialPort, new TransportDataEventArgs(tx, data));
        }

        protected void OnSerialReadException(string exStr, Exception e)
        {
            ExceptionReceived(this.iSerialPort, new ErrorReceivedEventArgs(exStr, e));
        }

        public ReaderMethod()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Console.WriteLine(string.Format("{0}", Thread.CurrentThread.CurrentCulture.Name));
            italker = new Talker();
            italker.EvRecvData += MessageReceived;
            italker.EvException += ExceptionReceived;

            iSerialPort = new SerialPort();
            iSerialPort.DataReceived += ISerialPort_DataReceived;
            iSerialPort.ErrorReceived += ISerialPort_ErrorReceived;

            ible = new Ble();
            ible.EvRecvData += MessageReceived;
            ible.EvException += ExceptionReceived;
        }

        private void ISerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            OnSerialReadException(e.EventType.ToString(), new Exception());
        }

        private void ISerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int nCount = iSerialPort.BytesToRead;

            if (nCount == 0)
            {
                return;
            }

            byte[] data = new byte[nCount];
            iSerialPort.Read(data, 0, nCount);
            OnSerialTransport(false, data);
        }

        private void MessageReceived(object sender, TransportDataEventArgs e)
        {
            OnTransport(sender, e);
            RunReceiveDataCallback(e.Data);
        }

        private void ExceptionReceived(object sender, ErrorReceivedEventArgs e)
        {
            ErrCallback?.Invoke(this, new ErrorReceivedEventArgs(e.ErrStr, e.Err));
        }

        private void OnTransport(object sender, TransportDataEventArgs e)
        {
            if (e.Tx)
            {
                SendCallback?.Invoke(sender, e.Data);
            }
            else
            {
                ReceiveCallback?.Invoke(sender, e);
            }
        }

        private void OnAnaly(MessageTran msgTran)
        {
            AnalyCallback?.Invoke(this, msgTran);
        }

        #region ConnectSerial
        public int OpenCom(string strPort, int nBaudrate, out string strException)
        {
            strException = string.Empty;

            if (iSerialPort.IsOpen)
            {
                iSerialPort.Close();
            }

            try
            {
                iSerialPort.PortName = strPort;
                iSerialPort.BaudRate = nBaudrate;
                iSerialPort.ReadTimeout = 200;
                iSerialPort.ReadBufferSize = 4096 * 10;
                iSerialPort.Open();
            }
            catch (Exception ex)
            {
                strException = ex.Message;
                return -1;
            }

            m_nType = ReaderType.SerialPort;
            return 0;
        }

        public void CloseCom()
        {
            if (iSerialPort.IsOpen)
            {
                iSerialPort.Close();
            }

            m_nType = ReaderType.Default;
        }
        #endregion ConnectSerial

        #region ConnectTcp
        public int ConnectServer(IPAddress ipAddress, int nPort, out string strException)
        {
            strException = string.Empty;

            if (!italker.Connect(ipAddress, nPort, out strException))
            {
                return -1;
            }

            m_nType = ReaderType.TCP;
            return 0;
        }

        public void SignOut()
        {
            italker.SignOut();
            m_nType = ReaderType.Default;
        }
        #endregion ConnectTcp

        #region ConnectBLE
        string serviceUUID = "0000fff0-0000-1000-8000-00805f9b34fb"; // 65520
        string subscribeUUID = "0000fff1-0000-1000-8000-00805f9b34fb";// 65521
        string writeUUID = "0000fff2-0000-1000-8000-00805f9b34fb";// 65522
        public void StartBLE(GattCharacteristic RecvGatt, GattCharacteristic SendGatt)
        {
            if (!RecvGatt.Uuid.ToString().Equals(subscribeUUID) || !SendGatt.Uuid.ToString().Equals(writeUUID))
            {
                return;
            }

            Console.WriteLine("StartBLE ...");
            ible.Recv = RecvGatt;
            ible.Send = SendGatt;
            //byte[] data = new byte[] { 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38 };
            ible.SendMessage(System.Text.Encoding.Default.GetBytes("12345678"));
            ible.Subscribe();
            ible.PowerOn();

            m_nType = ReaderType.BLE;
        }

        public void StopBLE()
        {
            Console.WriteLine("StopBLE ...");
            ible.Unsubscribe();
            ible.PowerOff();
            ible.Recv = null;
            ible.Send = null;
            m_nType = ReaderType.Default;
        }
        #endregion ConnectBLE

        private void RunReceiveDataCallback(byte[] btAryReceiveData)
        {
            try
            {
                int nCount = btAryReceiveData.Length;
                byte[] btAryBuffer = new byte[nCount + m_nLenth];
                Array.Copy(m_btAryBuffer, btAryBuffer, m_nLenth);
                Array.Copy(btAryReceiveData, 0, btAryBuffer, m_nLenth, btAryReceiveData.Length);

                //Analyze the received data with 0xA0 as the data starting point and the length of the data in the protocol as the data termination point
                int nIndex = 0;//When A0 is present in the data, the termination point of the data is recorded
                int nMarkIndex = 0;//When A0 is not present in the data, nMarkIndex is equal to the maximum index of the data group
                for (int nLoop = 0; nLoop < btAryBuffer.Length; nLoop++)
                {
                    if (btAryBuffer.Length > nLoop + 1)
                    {
                        if (btAryBuffer[nLoop] == 0xA0)
                        {
                            int nLen = Convert.ToInt32(btAryBuffer[nLoop + 1]);
                            if (nLoop + 1 + nLen < btAryBuffer.Length)
                            {
                                byte[] btAryAnaly = new byte[nLen + 2];
                                Array.Copy(btAryBuffer, nLoop, btAryAnaly, 0, nLen + 2);

                                MessageTran msgTran = new MessageTran(btAryAnaly);
                                //Console.WriteLine("---Recv: " + byteToHexStr(btAryAnaly));
                                OnAnaly(msgTran);

                                nLoop += 1 + nLen;
                                nIndex = nLoop + 1;
                            }
                            else
                            {
                                nLoop += 1 + nLen;
                            }
                        }
                        else
                        {
                            nMarkIndex = nLoop;
                        }
                    }
                }

                if (nIndex < nMarkIndex)
                {
                    nIndex = nMarkIndex + 1;
                }

                if (nIndex < btAryBuffer.Length)
                {
                    m_nLenth = btAryBuffer.Length - nIndex;
                    Array.Clear(m_btAryBuffer, 0, 4096 * 10);
                    Array.Copy(btAryBuffer, nIndex, m_btAryBuffer, 0, btAryBuffer.Length - nIndex);
                }
                else
                {
                    m_nLenth = 0;
                }
            }
            catch (Exception ex)
            {
                ErrCallback?.Invoke(this, new ErrorReceivedEventArgs(ex.Message, ex));
            }
        }

        public int SendMessage(byte[] btArySenderData)
        {
            //Console.WriteLine("Send: " + byteToHexStr(btArySenderData));
            if (m_nType == ReaderType.SerialPort)
            {
                if (!iSerialPort.IsOpen)
                {
                    return -1;
                }

                iSerialPort.Write(btArySenderData, 0, btArySenderData.Length);
                //OnSerialTransport(true, btArySenderData);
                OnTransport(this.iSerialPort, new TransportDataEventArgs(true, btArySenderData));
                return 0;
            }
            else if (m_nType == ReaderType.TCP)
            {
                if (!italker.IsConnect())
                {
                    return -1;
                }

                if (italker.SendMessage(btArySenderData))
                {
                    OnTransport(this.italker, new TransportDataEventArgs(true, btArySenderData));
                    return 0;
                }
            }
            else if (m_nType == ReaderType.BLE)
            {
                if(ible.SendMessage(btArySenderData))
                {
                    OnTransport(this.ible, new TransportDataEventArgs(true, btArySenderData));
                    return 0;
                }
            }

            return -1;
        }

        private int SendMessage(byte btReadId, byte btCmd)
        {
            MessageTran msgTran = new MessageTran(btReadId, btCmd);

            return SendMessage(msgTran.AryTranData);
        }

        private int SendMessage(byte btReadId, byte btCmd, byte[] btAryData)
        {
            MessageTran msgTran = new MessageTran(btReadId, btCmd, btAryData);

            return SendMessage(msgTran.AryTranData);
        }

        #region CMD
        #region CMD_6X
        public int ReadGpioValue(byte btReadId)
        {
            byte btCmd = 0x60;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue)
        {
            byte btCmd = 0x61;
            byte[] btAryData = new byte[2];
            btAryData[0] = btChooseGpio;
            btAryData[1] = btGpioValue;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetAntDetector(byte btReadId, byte btDetectorStatus)
        {
            byte btCmd = 0x62;
            byte[] btAryData = new byte[1];
            btAryData[0] = btDetectorStatus;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetAntDetector(byte btReadId)
        {
            byte btCmd = 0x63;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetTempOutpower(byte btReadId, byte btOutpower)
        {
            byte btCmd = 0x66;

            byte[] btAryData = new byte[1];
            btAryData[0] = btOutpower;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetReaderIdentifier(byte btReadId, byte[] identifier)
        {
            byte btCmd = 0x67;

            int nResult = SendMessage(btReadId, btCmd, identifier);

            return nResult;
        }

        public int GetReaderIdentifier(byte btReadId)
        {
            byte btCmd = 0x68;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetRadioProfile(byte btReadId, byte btProfile)
        {
            byte btCmd = 0x69;
            byte[] btAryData = new byte[1];
            btAryData[0] = btProfile;
            int nResult = SendMessage(btReadId, btCmd, btAryData);
            return nResult;
        }

        public int GetRadioProfile(byte btReadId)
        {
            byte btCmd = 0x6A;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetReaderAntGroup(byte btReadId, byte groupId)
        {
            byte btCmd = 0x6C;
            byte[] btAryData = new byte[1];
            btAryData[0] = groupId;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetReaderAntGroup(byte btReadId)
        {
            byte btCmd = 0x6D;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        #endregion //CMD_6X

        #region CMD_7X
        public int Reset(byte btReadId)
        {
            byte btCmd = 0x70;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetUartBaudrate(byte btReadId, int nIndexBaudrate)
        {
            byte btCmd = 0x71;
            byte[] btAryData = new byte[1];
            btAryData[0] = Convert.ToByte(nIndexBaudrate);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetFirmwareVersion(byte btReadId)
        {
            byte btCmd = 0x72;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetReaderAddress(byte btReadId, byte btNewReadId)
        {
            byte btCmd = 0x73;
            byte[] btAryData = new byte[1];
            btAryData[0] = btNewReadId;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetWorkAntenna(byte btReadId, byte btWorkAntenna)
        {
            byte btCmd = 0x74;
            byte[] btAryData = new byte[1];
            btAryData[0] = btWorkAntenna;
            int nResult = SendMessage(btReadId, btCmd, btAryData);
            return nResult;
        }

        public int GetWorkAntenna(byte btReadId)
        {
            byte btCmd = 0x75;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetOutputPower(byte btReadId, byte[] btOutputPower)
        {
            byte btCmd = 0x76;

            int nResult = SendMessage(btReadId, btCmd, btOutputPower);

            return nResult;
        }

        public int GetOutputPowerFour(byte btReadId)
        {
            byte btCmd = 0x77;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetFrequencyRegion(byte btReadId, byte btRegion, byte btStartRegion, byte btEndRegion)
        {
            byte btCmd = 0x78;
            byte[] btAryData = new byte[3];
            btAryData[0] = btRegion;
            btAryData[1] = btStartRegion;
            btAryData[2] = btEndRegion;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetUserDefineFrequency(byte btReadId, int nStartFreq, byte btFreqInterval, byte btChannelQuantity)
        {
            byte btCmd = 0x78;
            byte[] btAryFreq = new byte[3];
            byte[] btAryData = new byte[6];
            btAryFreq = BitConverter.GetBytes(nStartFreq);

            btAryData[0] = 4;
            btAryData[1] = btFreqInterval;
            btAryData[2] = btChannelQuantity;
            btAryData[3] = btAryFreq[2];
            btAryData[4] = btAryFreq[1];
            btAryData[5] = btAryFreq[0];

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetFrequencyRegion(byte btReadId)
        {
            byte btCmd = 0x79;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetBeeperMode(byte btReadId, byte btMode)
        {
            byte btCmd = 0x7A;
            byte[] btAryData = new byte[1];
            btAryData[0] = btMode;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetReaderTemperature(byte btReadId)
        {
            byte btCmd = 0x7B;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetDrmMode(byte btReadId, byte btDrmMode)
        {
            byte btCmd = 0x7C;
            byte[] btAryData = new byte[1];
            btAryData[0] = btDrmMode;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetDrmMode(byte btReadId)
        {
            byte btCmd = 0x7D;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int MeasureReturnLoss(byte btReadId, byte btFrequency)
        {
            byte btCmd = 0x7E;
            byte[] btAryData = new byte[1];
            btAryData[0] = btFrequency;
            int nResult = SendMessage(btReadId, btCmd, btAryData);
            return nResult;
        }

        public int GetAntImpedanceMatch(byte btReadId, byte btFrequency)
        {
            byte btCmd = 0x7E;
            byte[] btAryData = new byte[1];
            btAryData[0] = btFrequency;
            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        #endregion //CMD_7X

        #region CMD_8X
        public int Inventory(byte btReadId, byte byRound)
        {
            byte btCmd = 0x80;
            byte[] btAryData = new byte[1];
            btAryData[0] = byRound;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btPassword)
        {
            byte btCmd = 0x81;
            byte[] btAryData;
            if (btPassword == null)
            {
                btAryData = new byte[3];
            }
            else
            {
                btAryData = new byte[3 + btPassword.Length];
            }
            btAryData[0] = btMemBank;
            btAryData[1] = btWordAdd;
            btAryData[2] = btWordCnt;
            if (btPassword != null)
            {
                btPassword.CopyTo(btAryData, 3);
            }
            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData)
        {
            byte btCmd = 0x82;
            byte[] btAryBuffer = new byte[btAryData.Length + 7];
            btAryPassWord.CopyTo(btAryBuffer, 0);
            btAryBuffer[4] = btMemBank;
            btAryBuffer[5] = btWordAdd;
            btAryBuffer[6] = btWordCnt;
            btAryData.CopyTo(btAryBuffer, 7);

            int nResult = SendMessage(btReadId, btCmd, btAryBuffer);

            return nResult;
        }

        public int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType)
        {
            byte btCmd = 0x83;
            byte[] btAryData = new byte[6];
            btAryPassWord.CopyTo(btAryData, 0);
            btAryData[4] = btMembank;
            btAryData[5] = btLockType;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int KillTag(byte btReadId, byte[] btAryPassWord)
        {
            byte btCmd = 0x84;
            byte[] btAryData = new byte[4];
            btAryPassWord.CopyTo(btAryData, 0);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int CancelAccessEpcMatch(byte btReadId, byte btMode)
        {
            byte btCmd = 0x85;
            byte[] btAryData = new byte[1];
            btAryData[0] = btMode;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc)
        {
            byte btCmd = 0x85;
            int nLen = Convert.ToInt32(btEpcLen) + 2;
            byte[] btAryData = new byte[nLen];
            btAryData[0] = btMode;
            btAryData[1] = btEpcLen;
            btAryEpc.CopyTo(btAryData, 2);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetAccessEpcMatch(byte btReadId)
        {
            byte btCmd = 0x86;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int InventoryReal(byte btReadId, byte byRound)
        {
            byte btCmd = 0x89;
            byte[] btAryData = new byte[1];
            btAryData[0] = byRound;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int FastSwitchInventory(byte btReadId, byte[] btAryData)
        {
            byte btCmd = 0x8A;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int CustomizedInventoryV2(byte btReadId, byte[] parameters)
        {
            byte btCmd = 0x8B;
            byte[] btAryData = new byte[parameters.Length];
            parameters.CopyTo(btAryData, 0);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int CustomizedInventory(byte btReadId, byte session, byte target, byte byRound)
        {
            byte btCmd = 0x8B;
            byte[] btAryData = new byte[3];
            btAryData[0] = session;
            btAryData[1] = target;
            btAryData[2] = byRound;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetMonzaStatus(byte btReadId, byte btMonzaStatus)
        {
            byte btCmd = 0x8D;
            byte[] btAryData = new byte[1];
            btAryData[0] = btMonzaStatus;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetMonzaStatus(byte btReadId)
        {
            byte btCmd = 0x8E;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        #endregion //CMD_8X

        #region CMD_9X
        public int GetInventoryBuffer(byte btReadId)
        {
            byte btCmd = 0x90;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int GetAndResetInventoryBuffer(byte btReadId)
        {
            byte btCmd = 0x91;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int GetInventoryBufferTagCount(byte btReadId)
        {
            byte btCmd = 0x92;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int ResetInventoryBuffer(byte btReadId)
        {
            byte btCmd = 0x93;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int BlockWrite(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData)
        {
            byte btCmd = 0x94;
            byte[] btAryBuffer = new byte[btAryData.Length + 7];
            btAryPassWord.CopyTo(btAryBuffer, 0);
            btAryBuffer[4] = btMemBank;
            btAryBuffer[5] = btWordAdd;
            btAryBuffer[6] = btWordCnt;
            btAryData.CopyTo(btAryBuffer, 7);

            int nResult = SendMessage(btReadId, btCmd, btAryBuffer);

            return nResult;
        }

        public int GetBufferDataFrameInterval(byte btReadId)
        {
            byte btCmd = 0x95;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int GetOutputPower(byte btReadId)
        {
            byte btCmd = 0x97;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        #endregion //CMD_9X

        #region CMD_BX
        public int InventoryISO18000(byte btReadId)
        {
            byte btCmd = 0xb0;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt)
        {
            byte btCmd = 0xb1;
            int nLen = btAryUID.Length + 2;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 2] = btWordAdd;
            btAryData[nLen - 1] = btWordCnt;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer)
        {
            byte btCmd = 0xb2;
            int nLen = btAryUID.Length + 2 + btAryBuffer.Length;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[btAryUID.Length] = btWordAdd;
            btAryData[btAryUID.Length + 1] = btWordCnt;
            btAryBuffer.CopyTo(btAryData, btAryUID.Length + 2);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            byte btCmd = 0xb3;
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            byte btCmd = 0xb4;
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int setTagMask(byte btReadId, byte btMaskNo, byte btTarget, byte btAction, byte btMembank, byte btStartAdd, byte btMaskLen, byte[] maskValue)
        {
            byte bCmd = (byte)CMD.cmd_tag_select;
            byte[] btAryData = new byte[7 + maskValue.Length];
            btAryData[0] = btMaskNo;
            btAryData[1] = btTarget;
            btAryData[2] = btAction;
            btAryData[3] = btMembank;
            btAryData[4] = btStartAdd;
            btAryData[5] = btMaskLen;
            maskValue.CopyTo(btAryData, 6);
            btAryData[btAryData.Length - 1] = (byte)0x00;

            int nResult = SendMessage(btReadId, bCmd, btAryData);

            return nResult;
        }

        public int getTagMask(byte btReadId)
        {
            byte bCmd = (byte)CMD.cmd_tag_select;
            byte[] btAryData = { (byte)0x20 };
            int nResult = SendMessage(btReadId, bCmd, btAryData);

            return nResult;
        }

        public int clearTagMask(byte btReadId, byte btMaskNO)
        {
            byte bCmd = (byte)CMD.cmd_tag_select;
            byte[] btAryData = { btMaskNO };
            int nResult = SendMessage(btReadId, bCmd, btAryData);

            return nResult;
        }
        #endregion //CMD_BX
        #endregion //CMD
    }

    enum ReaderType
    {
        Default,
        SerialPort,
        TCP,
        BLE
    }

    public enum CMD
    {
        cmd_read_gpio_value = 0x60,
        cmd_write_gpio_value = 0x61,
        cmd_set_ant_connection_detector = 0x62,
        cmd_get_ant_connection_detector = 0x63,
        cmd_set_temporary_output_power = 0x66,
        cmd_set_reader_identifier = 0x67,
        cmd_get_reader_identifier = 0x68,
        cmd_set_rf_link_profile = 0x69,
        cmd_get_rf_link_profile = 0x6A,
        cmd_set_antenna_group = 0x6C,
        cmd_get_antenna_group = 0x6D,

        cmd_reset = 0x70,
        cmd_set_uart_baudrate = 0x71,
        cmd_get_firmware_version = 0x72,
        cmd_set_reader_address = 0x73,
        cmd_set_work_antenna = 0x74,
        cmd_get_work_antenna = 0x75,
        cmd_set_output_power = 0x76,
        [Obsolete("this command is Deprecated")]
        cmd_get_output_power = 0x77,
        cmd_set_frequency_region = 0x78,
        cmd_get_frequency_region = 0x79,
        cmd_set_beeper_mode = 0x7A,
        cmd_get_reader_temperature = 0x7B,
        cmd_set_drm_mode = 0x7C,
        cmd_get_drm_mode = 0x7D,
        cmd_get_rf_port_return_loss = 0x7E,

        cmd_inventory = 0x80,
        cmd_read = 0x81,
        cmd_write = 0x82,
        cmd_lock = 0x83,
        cmd_kill = 0x84,
        cmd_set_access_epc_match = 0x85,
        cmd_get_access_epc_match = 0x86,
        cmd_real_time_inventory = 0x89,
        cmd_fast_switch_ant_inventory = 0x8A,
        cmd_customized_session_target_inventory = 0x8B,
        cmd_set_impinj_fast_tid = 0x8C,
        cmd_set_and_save_impinj_fast_tid = 0x8D,
        cmd_get_impinj_fast_tid = 0x8E,

        cmd_get_inventory_buffer = 0x90,
        cmd_get_and_reset_inventory_buffer = 0x91,
        cmd_get_inventory_buffer_tag_count = 0x92,
        cmd_reset_inventory_buffer = 0x93,
        cmd_block_write = 0x94,
        //SetBufferDataFrameInterval = 0x94,
        //GetBufferDataFrameInterval = 0x95,
        cmd_get_output_power_eight = 0x97,
        cmd_tag_select = 0x98,

        // HardwareCalibrate
        //cmdSetCustomFunctionID = 0xA0 id
        cmdGetCustomFunctionID = 0xA1,
        cmd_open_all_ldo_voltage = 0xA2,
        cmdHardwareCalibrate = 0xA3,
        // cmdTestCenterFreqOutputPower = A3 00
        // cmdTestPllLock = A3 01
        // cmdTestPD_1 = A3 02
        // cmdTestPD_2 = A3 03
        // cmdTestAllFreqOutputPower = A3 04
        // cmdTestAutoCalibrateAntennaDetect = A3 10
        // cmdResetCalibrateValue = A3 11
        cmd_get_calibrate_value = 0xA4,
        cmd_get_internal_version = 0xAA,

        // ISO18000 6B
        cmd_iso18000_6b_inventory = 0xB0,
        cmd_iso18000_6b_read = 0xB1,
        cmd_iso18000_6b_write = 0xB2,
        cmd_iso18000_6b_lock = 0xB3,
        cmd_iso18000_6b_query_lock = 0xB4,

        // NXP
        cmd_nxp_untraceable = 0xE1,
        cmd_change_eas = 0xE4,

        // Bluetooth
        cmdGetBluetoothVersion = 0xF0,
        cmdGetBluetoothMac = 0xF1,
        cmdSetBluetoothBroadcastAddr = 0xF2,
        cmdGetBluetoothBoardSn = 0xF3,
        cmdSetBluetoothBoardSn = 0xF4,
        cmdBluetoothShutDown = 0xF5,
        cmdGetBluetoothBoardVersion = 0xF6,
        cmdGetBluetoothVoltage = 0xF7,
        cmdSetBluetoothBuzzer = 0xF8,
        cmdSetBluetoothEnableMode = 0xF9,
        cmdRecvBluetoothReserved = 0xFA,      // single direction Recv
        cmdRecvBluetoothBoardSleep = 0xFB,    // single direction Recv
        cmdRecvBluetoothTriggerKey = 0xFC,    // single direction Recv

        // FuDan
        cmd_fundan = 0xFD,
    }
}
