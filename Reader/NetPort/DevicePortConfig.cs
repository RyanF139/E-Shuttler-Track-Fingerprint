using System;

namespace Reader
{
    public class DevicePortConfig
    {
		public byte[] message;
		public int writeIndex;
		public int readIndex;
		public int optIndex;

		// 65
        public int Index { get { return getu8at(0); } }                                                        //The port number
        public bool PortEn { get { return (getu8at(1) == 1 ? true : false); } }                                //Port enabled flag 1: after enabled; 0: Not enabled
        public int NetMode { get { return getu8at(2); } }                                                      //Network working mode: 0: TCP SERVER; 1: TCP CLENT;  2: UDP SERVER 3: UDP CLIENT;
        public bool RandSportFlag { get { return (getu8at(3) == 1 ? true : false); } }                         //TCP client mode, then the local port number, 1: random 0: not random
        public int NetPort { get { return getPortAt(4); } }                                                    //[2] Network communication port number
        public string DesIP { get { return getIpAddr(getbytes(6, 4)); } }                                      //[4] Destination IP address
        public int DesPort { get { return getPortAt(10); } }                                                   //[2] The port number that allows external connections when working in TCP Server mode
        public int BaudRate { get { return getLengthAt(12); } }                                                //[4] BaudRate: 300---921600bps
        public int DataSize { get { return getu8at(16); } }                                                    //DataBits: 5---8位
        public int StopBits { get { return getu8at(17); } }                                                    //StopBits: 1 represents a stop bit; Two means two stop bits
        public int Parity { get { return getu8at(18); } }                                                      //Parity: 0 means odd check; 1 stands for parity; 2 represents the MARK (set 1); 3 represents the blank SPACE (SPACE, clear 0);
        public bool PHYChangeHandle { get { return (getu8at(19) == 1 ? true : false); } }                      //Phys disconnected, Socket action, 1: Socket 2 closed, no action
        public int RxPktlength { get { return getLengthAt(20); } }                                             //[4] Serial port RX data packaging length, maximum 1024
        public int RxPktTimeout { get { return getLengthAt(24); } }                                            //[4] The maximum wait time of serial PORT RX data packaging and forwarding, unit: 10ms,0 means to turn off the timeout function
        public int ReConnectCnt { get { return getu8at(28); } }                                                //Maximum number of retries to connect to THE TCP SERVER while working with the TCP CLIENT
        public bool ResetCtrl { get { return (getu8at(29) == 1 ? true : false); } }                            //Serial port reset operation: 0 means not to empty the serial port data buffer; 1 means to clear the serial data buffer when connecting
        public bool DNSFlag { get { return (getu8at(30) == 1 ? true : false); } }                              //Domain name function enabled mark, 1: enabled 2: not enabled
        public string Domainname { get { return System.Text.Encoding.Default.GetString(getbytes(31, 20)); } }  //[20]Domain
        public string DNSHostIP { get { return getIpAddr(getbytes(51, 4)); } }                                 //[4] DNS Host
        public int DNSHostPort { get { return getPortAt(55); } }                                               //[2] DNS Port
        public string Reserved { get { return System.Text.Encoding.Default.GetString(getbytes(57, 8)); } }     //[8] Reserved

        public DevicePortConfig(byte[] data)
        {
            message = new byte[65];
            if (data.Length > 65)
                Array.Copy(data, 0, message, 0, 65);
            else
                setbytes(data);
        }

        public override string ToString()
        {
            return string.Format(
                $"\r\nbIndex={Index}, " +
                $"\r\nbPortEn={PortEn}, " +
                $"\r\nbNetMode={NetMode}, " +
                $"\r\nbRandSportFlag={RandSportFlag}, " +
                $"\r\nwNetPort={NetPort}, " +
                $"\r\nDes={DesIP}:{DesPort}, " +
                $"\r\nPort={BaudRate}:{DataSize}:{StopBits}:{Parity}, " +
                $"\r\nbPHYChangeHandle={PHYChangeHandle}, " +
                $"\r\ndRxPktlength={RxPktlength}, dRxPktTimeout={RxPktTimeout}, " +
                $"\r\nbReConnectCnt={ReConnectCnt}, " +
                $"\r\nbResetCtrl={ResetCtrl}, " +
                $"\r\nDNS={DNSFlag},domain={Domainname}, {DNSHostIP}:{DNSHostPort}, " +
                $"\r\nbReserved={Reserved}");
        }

        string getMacAddr(byte[] bytes)
        {
            return ReaderUtils.ToHex(bytes, "", ":");
        }

        string getIpAddr(byte[] bytes)
        {
            return string.Format("{0}.{1}.{2}.{3}", bytes[0], bytes[1], bytes[2], bytes[3]);
        }

        private int getPortAt(int offset)
        {
            return ((message[offset] & 0xff) << 0)
              | ((message[offset + 1] & 0xff) << 8);
        }

        int getLengthAt(int offset)
        {
            return ((message[offset] & 0xff) << 0)
              | ((message[offset + 1] & 0xff) << 8)
              | ((message[offset + 2] & 0xff) << 16)
              | ((message[offset + 3] & 0xff) << 24);
        }

        public void setu8(int val)
        {
            message[writeIndex++] = (byte)(val & 0xff);
        }

        void setu16(int val)
        {
            message[writeIndex++] = (byte)((val >> 8) & 0xff);
            message[writeIndex++] = (byte)((val >> 0) & 0xff);
        }

        void setu24(int val)
        {
            message[writeIndex++] = (byte)((val >> 16) & 0xff);
            message[writeIndex++] = (byte)((val >> 8) & 0xff);
            message[writeIndex++] = (byte)((val >> 0) & 0xff);
        }

        void setu32(int val)
        {
            message[writeIndex++] = (byte)((val >> 24) & 0xff);
            message[writeIndex++] = (byte)((val >> 16) & 0xff);
            message[writeIndex++] = (byte)((val >> 8) & 0xff);
            message[writeIndex++] = (byte)((val >> 0) & 0xff);
        }

        public void setbytes(byte[] array)
        {
            if (array != null)
            {
                setbytes(array, 0, array.Length);
            }
        }

        void setbytes(byte[] array, int start, int length)
        {
            Array.Copy(array, start, message, writeIndex, length);
            writeIndex += length;
        }

        int getu8at(int offset)
        {
            return message[offset] & 0xff;
        }

        int getu16at(int offset)
        {
            return ((message[offset] & 0xff) << 8)
              | ((message[offset + 1] & 0xff) << 0);
        }

        int getu24at(int offset)
        {
            return ((message[offset] & 0xff) << 16)
              | ((message[offset + 1] & 0xff) << 8)
              | ((message[offset + 2] & 0xff) << 0);
        }

        int getu32at(int offset)
        {
            return ((message[offset] & 0xff) << 24)
              | ((message[offset + 1] & 0xff) << 16)
              | ((message[offset + 2] & 0xff) << 8)
              | ((message[offset + 3] & 0xff) << 0);
        }

        byte[] getbytes(int offset, int len)
        {
            byte[] bytes = new byte[len];
            Array.Copy(message, offset, bytes, 0, len);
            return bytes;
        }
    }
}