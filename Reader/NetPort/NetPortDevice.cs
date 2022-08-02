using System;
using System.ComponentModel;

namespace Reader
{
    public class NetPortDevice : INotifyPropertyChanged
    {
        NET_COMM RawCOMM;
        private int serialNo = 0;

        public int SerialNumber
        {
            get { return serialNo; }
            set { serialNo = value; }
        }
        public string DeviceName { get { return RawCOMM.FoundDev.DevName; } }
        public string DeviceIp { get { return RawCOMM.FoundDev.DevIp; } }
        public string DeviceMac { get { return RawCOMM.DevMac; } }
        public int ChipVer { get { return RawCOMM.FoundDev.DevVer; } }
        public string PcMac { get { return RawCOMM.PcMac; } }

        public NetPortDevice(NET_COMM addData)
        {
            RawCOMM = addData;
        }

        public void Update(NET_COMM addData)
        {
            RawCOMM = addData;
            OnPropertyChanged(null);
        }

        public override string ToString()
        {
            return string.Format($"{DeviceName}, {DeviceIp}, {DeviceMac}, {ChipVer}, {PcMac}");
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