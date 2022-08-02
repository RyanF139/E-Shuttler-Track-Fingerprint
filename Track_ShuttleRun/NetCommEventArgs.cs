using Reader;

namespace Track_ShuttleRun
{
    public class NetCommEventArgs
    {
        NET_COMM comm;
        public NetCommEventArgs(NET_COMM comm)
        {
            this.comm = comm;
        }

        public NET_COMM NetComm { get { return comm; } }
    }
}