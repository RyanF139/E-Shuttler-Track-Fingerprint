using System;

namespace Reader
{
    public class TransportDataEventArgs : EventArgs
    {
        private byte[] data;
        private bool tx;
        public TransportDataEventArgs(bool tx, byte[] transportData)
        {
            this.tx = tx;
            this.data = new byte[transportData.Length];
            Array.Copy(transportData, this.data, transportData.Length);
        }

        public byte[] Data { get { return data; } }
        public bool Tx { get { return tx; } }
    }
}