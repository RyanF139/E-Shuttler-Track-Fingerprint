using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;

namespace Reader
{
    public class Ble : IBle
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

        private GattCharacteristic recvGatt;
        private GattCharacteristic sendGatt;

        GattCharacteristic IBle.Recv 
        {
            set { recvGatt = value; }
            get {return recvGatt; }
        }
        GattCharacteristic IBle.Send 
        {
            set { sendGatt = value; }
            get { return sendGatt; }
        }


        private void RecvGatt_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs gattValue)
        {
            OnTransport(false, WindowsRuntimeBufferExtensions.ToArray(gattValue.CharacteristicValue));
        }

        public void PowerOff()
        {
            Console.WriteLine("PowerOff");
            int writeIndex = 0;
            byte[] data = new byte[256];
            data[writeIndex++] = 0xA0;
            data[writeIndex++] = 0x03;
            data[writeIndex++] = 0x01;
            data[writeIndex++] = 0xF9;
            data[writeIndex++] = 0x01;
            data[writeIndex++] = 0x00;

            int msgLen = writeIndex + 1;
            data[1] = (byte)(msgLen - 2);// except hdr + len
            data[writeIndex] = ReaderUtils.CheckSum(data, 0, msgLen);

            Array.Resize(ref data, msgLen);

            SendMessageAsync(data);
        }

        public void PowerOn()
        {
            Console.WriteLine("PowerOn");
            int writeIndex = 0;
            byte[] data = new byte[256];
            data[writeIndex++] = 0xA0;
            data[writeIndex++] = 0x03;
            data[writeIndex++] = 0x01;
            data[writeIndex++] = 0xF9;
            data[writeIndex++] = 0x01;
            data[writeIndex++] = 0x01;

            int msgLen = writeIndex + 1;
            data[1] = (byte)(msgLen - 2);// except hdr + len
            data[writeIndex] = ReaderUtils.CheckSum(data, 0, msgLen);

            Array.Resize(ref data, msgLen);
            SendMessageAsync(data);
        }

        public void Subscribe()
        {
            SubscribeAsync();
        }

        public void Unsubscribe()
        {
            UnsubscribeAsync();
        }

        public async System.Threading.Tasks.Task<bool> SubscribeAsync()
        {
            Console.WriteLine("Subscribe");
            var cccdValue = GattClientCharacteristicConfigurationDescriptorValue.None;
            if (recvGatt.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Indicate))
            {
                cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Indicate;
            }

            else if (recvGatt.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
            {
                cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Notify;
            }

            try
            {
                var result = await recvGatt.WriteClientCharacteristicConfigurationDescriptorAsync(cccdValue);

                if (result == GattCommunicationStatus.Success)
                {
                    recvGatt.ValueChanged += RecvGatt_ValueChanged; ;
                    return true;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return false;
            }
            return false;
        }

        public async System.Threading.Tasks.Task UnsubscribeAsync()
        {
            Console.WriteLine("Unsubscribe");
            var result = await recvGatt.WriteClientCharacteristicConfigurationDescriptorAsync(
                                GattClientCharacteristicConfigurationDescriptorValue.None);
            if (result == GattCommunicationStatus.Success)
            {
                recvGatt.ValueChanged -= RecvGatt_ValueChanged;
                recvGatt = null;
            }
        }

        public async System.Threading.Tasks.Task<bool> SendMessageAsync(byte[] data)
        {
            try
            {
                DataWriter writer = new DataWriter();
                writer.WriteBytes(data);
                var result = await sendGatt.WriteValueAsync(writer.DetachBuffer());
                return true;
            }
            catch (Exception e)
            {
                string exStr = String.Format("send data failed: HResult={0:x8}", e.HResult);
                OnReadException(exStr, e);
                return false;
            }
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

        public static byte[] FromHex(string hex)
        {
            int prelen = 0;

            if (hex.StartsWith("0x") || hex.StartsWith("0X"))
                prelen = 2;

            byte[] bytes = new byte[(hex.Length - prelen) / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                string bytestring = hex.Substring(prelen + (2 * i), 2);
                bytes[i] = byte.Parse(bytestring, System.Globalization.NumberStyles.HexNumber);
            }

            return bytes;
        }

        public bool SendMessage(byte[] data)
        {
            SendMessageAsync(data);
            return true;
        }
    }
}