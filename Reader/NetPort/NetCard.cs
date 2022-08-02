using System;
using System.ComponentModel;

namespace Reader
{
    public class NetCard : INotifyPropertyChanged
    {
        private string desc;
        private string pcIpaddr;
        private string pcMask;
        private string pcMac;

        private int serialNo = 0;

        public NetCard(string desc, string pcIpaddr, string pcMask, string pcMac)
        {
            this.desc = desc;
            this.pcIpaddr = pcIpaddr;
            this.pcMask = pcMask;
            this.pcMac = pcMac;
        }

        public int SerialNumber
        {
            get { return serialNo; }
            set { serialNo = value; }
        }

        public string Description { get { return desc; } }
        public string Ip { get { return pcIpaddr; } }
        public string Mask { get { return pcMask; } }
        public string Mac { get { return pcMac; } }

        public override string ToString()
        {
            return string.Format("{0}", desc);
            //return string.Format("desc={0},ip={1},mask={2},mac={3}", desc, pcIpaddr, pcMask, pcMac);
        }

        public void Update(NetCard mergeData)
        {
            OnPropertyChanged(null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventArgs td = new PropertyChangedEventArgs(name);
            try
            {
                if (null != PropertyChanged)
                {
                    PropertyChanged(this, td);
                }
            }
            finally
            {
                td = null;
            }
        }
    }
}