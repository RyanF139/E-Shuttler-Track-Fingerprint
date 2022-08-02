using System;
using System.Net;

namespace Reader
{
    interface ITalker
    {
        event EventHandler<TransportDataEventArgs> EvRecvData;
        event EventHandler<ErrorReceivedEventArgs> EvException;

        bool Connect(IPAddress ip, int port, out string strException);// Connect to the server
        bool SendMessage(byte[] btAryBuffer);//Send data
        void SignOut();

        bool IsConnect();// Check whether the server is connected
    }
}
