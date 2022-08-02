using System;

namespace Reader
{
    public class FoundDevice
    {
        public byte[] message;
        public int writeIndex;
        public int readIndex;
        public int optIndex;

        public int Len { get { return message.Length; } }
        public string DevIp { get { return getIpAddr(getbytes(0, 4)); } }
        public string DevName { get { return System.Text.Encoding.Default.GetString(getbytes(4, Len - 6)); } }
        public int DevVer { get { return getu8at(Len - 1); } }

        public FoundDevice(byte[] data)
        {
            writeIndex = 0;
            message = new byte[data.Length];
            setbytes(data);
        }

        public override string ToString()
        {
            return string.Format($"DevIp={DevIp}, " +
                $"DevName={DevName}, " +
                $"DevVer={DevVer}");
        }

        string getMacAddr(byte[] bytes)
        {
            return ReaderUtils.ToHex(bytes, "", ".");
        }

        string getIpAddr(byte[] bytes)
        {
            return string.Format("{0}.{1}.{2}.{3}", bytes[0], bytes[1], bytes[2], bytes[3]);
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