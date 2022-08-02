using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Reader
{
    public class Talker:ITalker
    {
        public event EventHandler<TransportDataEventArgs> EvRecvData;
        public event EventHandler<ErrorReceivedEventArgs> EvException;
        protected void OnTransport(bool tx, byte[] data)
        {
            EvRecvData?.Invoke(this, new TransportDataEventArgs(tx, data));
        }

        protected void OnReadException(string exStr, Exception e)
        {
            EvException?.Invoke(this, new ErrorReceivedEventArgs(exStr, e));
        }

        //TcpClient client;
        Socket tcpClient;
        private Thread waitThread = null;
        private bool firstConnect = true;

        private bool bIsConnect = false;
        private IPAddress ipAddress;
        private int nPort;
        private int tryReconnectTimes = 0;
        private bool isRecv = false;
        private bool receving = false;
        private bool isReconnect = false;
        private bool reconnecting = false;
        private Thread reconnectThread = null;

        private const int connectTimeout = 1000; // connect timeout

        public bool Connect(IPAddress ipAddress, int nPort, out string strException)
        {
            bool ret = false;
            if (firstConnect)
            {
                this.ipAddress = ipAddress;
                this.nPort = nPort;
                firstConnect = false;
            }

            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }
            strException = String.Empty;

            tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult ar = tcpClient.BeginConnect(ipAddress, nPort, null, null);
            bool success = ar.AsyncWaitHandle.WaitOne(connectTimeout);
            if (!success)
            {
                strException = String.Format("[{0}@{1}] Connect timeout，Failed to connect to the specified server", ipAddress.ToString(), nPort);
                ret = false;
            }
            else
            {
                try
                {
                    tcpClient.EndConnect(ar);
                    // Start KeppAlive detection
                    if (tcpClient != null)
                    {
                        tcpClient.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 300, 300), null);//Set the keep-alive parameter
                    }

                    if (!IsConnect())
                    {
                        // Set up a thread to receive data from the server
                        ThreadStart stThead = new ThreadStart(ReceivedData);
                        waitThread = new Thread(stThead);
                        waitThread.IsBackground = true;
                        waitThread.Start();
                    }

                    bIsConnect = true;
                    ret = true;
                }
                catch (Exception e)
                {
                    strException = String.Format("[{0}@{1}] Connect Error: HResult={2:x8}", ipAddress.ToString(), nPort, e.HResult);
                    Thread.Sleep(connectTimeout);
                    ret = false;
                }
            }
            return ret;
        }

        private byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval)
        {
            byte[] buffer = new byte[12];
            BitConverter.GetBytes(onOff).CopyTo(buffer, 0); // Whether to enable Keep-alive
            BitConverter.GetBytes(keepAliveTime).CopyTo(buffer, 4); // How long will it take for the first probe to start (in milliseconds)
            BitConverter.GetBytes(keepAliveInterval).CopyTo(buffer, 8);// Detection time interval (in milliseconds)
            return buffer;
        }

        private void ReceivedData()
        {
            isRecv = true;
            receving = true;
            while (isRecv)
            {
                if (reconnecting)
                    continue;
                if (tcpClient.Poll(3000, SelectMode.SelectRead))
                {
                    try
                    {
                        byte[] btAryBuffer = new byte[4096 * 10];
                        int nLenRead = tcpClient.Receive(btAryBuffer);
                        if (nLenRead == 0)
                        {
                            continue;
                        }
                        if (EvRecvData != null)
                        {
                            byte[] btAryReceiveData = new byte[nLenRead];

                            Array.Copy(btAryBuffer, btAryReceiveData, nLenRead);

                            OnTransport(false, btAryReceiveData);
                        }
                    }
                    catch (Exception ex)
                    {
                        string exStr = String.Empty;
                        if (ex is SocketException)
                        {
                            SocketError err = ((SocketException)ex).SocketErrorCode;
                            exStr = String.Format("[{0}@{1}] Data Receive Error: HResult={2:x8}", ipAddress.ToString(), nPort, ex.HResult);
                            if (err.Equals(SocketError.ConnectionReset))
                            {
                                OnReadException(exStr, ex);
                                Reconnect();
                            }
                            else
                            {
                                Console.WriteLine("SocketError={0}", err.ToString());
                            }
                        }
                    }
                }
            }
            receving = false;
        }

        private void Reconnect()
        {
            reconnecting = true;
            reconnectThread = new Thread(new ThreadStart(TryReconnect));
            reconnectThread.Start();
        }

        private void TryReconnect()
        {
            isReconnect = true;
            reconnecting = true;
            string exStr = String.Empty;
            while (isReconnect)
            {
                if (Connect(this.ipAddress, this.nPort, out string strException))
                {
                    exStr = String.Format("[{0}@{1}] [{2}] times Reconnect Success!", ipAddress.ToString(), nPort, tryReconnectTimes);
                    isReconnect = false;
                }
                else
                {
                    exStr = String.Format("[{0}@{1}] [{2}]times Reconnect Failed! {3}", ipAddress.ToString(), nPort, tryReconnectTimes++, strException);
                }
                OnReadException(exStr, new Exception());
            }
            reconnecting = false;
            tryReconnectTimes = 0;
        }

        public bool SendMessage(byte[] btAryBuffer)
        {
            try
            {
                lock (tcpClient)
                {
                    tcpClient.Send(btAryBuffer);
                    return true;
                }
            }
            catch (Exception e)
            {
                string exStr = String.Format("[{0}@{1}] Send Data Failed, HResult={2:x8}", ipAddress.ToString(), nPort, e.HResult);
                OnReadException(exStr, e);
                return false;
            }
        }

        public void SignOut()
        {
            //Console.WriteLine("SignOut");
            string exStr = String.Format("[{0}@{1}] Logout!", ipAddress.ToString(), nPort);
            OnReadException(exStr, new Exception());
            Console.WriteLine("SignOut isRecv={0}, isReconnect={1}", isRecv, isReconnect);
            isReconnect = false;
            isRecv = false;
            bIsConnect = false;
            firstConnect = true;

            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }
        }

        public bool IsConnect()
        {
            return bIsConnect;
        }

        private string ToHex(byte[] bytes, string prefix, string separator)
        {
            if (null == bytes)
                return "null";

            List<string> bytestrings = new List<string>();

            foreach (byte b in bytes)
                bytestrings.Add(b.ToString("X2"));

            return prefix + String.Join(separator, bytestrings.ToArray());
        }
    }
}