using System;

namespace Reader
{
    public class DeviceHWConfig
    {
        public byte[] message;
        public int writeIndex;
        public int readIndex;
        public int optIndex;

        // 74
        public int DevType { get { return getu8at(0); } }                                                    //Device type, see device type table for details
        public int AuxDevType { get { return getu8at(1); } }                                                 //AuxType
        public int Index { get { return getu8at(2); } }                                                      //Equipment serial number
        public int DevHardwareVer { get { return getu8at(3); } }                                             //Hardware version number of the device
        public int DevSoftwareVer { get { return getu8at(4); } }                                             //Device software version number
        public string Modulename { get { return System.Text.Encoding.Default.GetString(getbytes(5, 21)); } } //[21]Module name
        public string DevMAC { get { return getMacAddr(getbytes(26, 6)); } }                                 //[6]Module network MAC address
        public string DevIP { get { return getIpAddr(getbytes(32, 4)); } }                                   //[4]Module IP address
        public string DevGWIP { get { return getIpAddr(getbytes(36, 4)); } }                                 //[4]Module gateway IP
        public string DevIPMask { get { return getIpAddr(getbytes(40, 4)); } }                               //[4]Module subnet mask
        public bool DhcpEnable { get { return (getu8at(44) == 1 ? true : false); } }                         //DHCP Enable, whether DHCP is enabled,1: enabled, 0: not enabled
        public int WebPort { get { return getPortAt(45); } }                                                 //[2]WEB page address
        public string Username { get { return System.Text.Encoding.Default.GetString(getbytes(47, 8)); } }   //[8]The username is the same as the module name
        public bool PassWordEn { get { return (getu8at(55) == 1 ? true : false); } }                         //Password enable 1: enable 0: Disable
        public string PassWord { get { return System.Text.Encoding.Default.GetString(getbytes(56, 8)); } }   //[8]Password
        public bool UpdateFlag { get { return (getu8at(64) == 1 ? true : false); } }                         //Firmware upgrade mark, 1: Upgrade 0: No upgrade
        public bool ComcfgEn { get { return (getu8at(65) == 1 ? true : false); } }                           //Serial port negotiation into configuration mode enable, 1: enable 0: disable
        public string Reserved { get { return System.Text.Encoding.Default.GetString(getbytes(66, 8)); } }   //[8]Reserved

        public DeviceHWConfig(byte[] data)
        {
            message = new byte[74];
            if (data.Length > 74)
                Array.Copy(data, 0, message, 0, 74);
            else
                setbytes(data);
        }

        public override string ToString()
        {
            return string.Format(
                $"\r\nbType={DevType:x2}.{AuxDevType:x2}, " +
                $"\r\nbIndex={Index}, " +
                $"\r\nhwVer={DevHardwareVer}, swVer={DevSoftwareVer}, " +
                $"\r\nszModulename={Modulename}, " +
                $"\r\nDev: mac={DevMAC}, ip={DevIP}, gateway={DevGWIP}, mask={DevIPMask}, " +
                $"\r\nbDhcpEnable={DhcpEnable}, " +
                $"\r\nwWebPort={WebPort}, " +
                $"\r\nUser={Username}@[{PassWordEn}] {PassWord}, " +
                $"\r\nbUpdateFlag={UpdateFlag}, " +
                $"\r\nbComcfgEn={ComcfgEn}" +
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