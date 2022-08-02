using System;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace Reader
{
    interface IBle
    {
        GattCharacteristic Recv { get; set; }
        GattCharacteristic Send { get; set; }

        event EventHandler<TransportDataEventArgs> EvRecvData;
        event EventHandler<ErrorReceivedEventArgs> EvException;

        bool SendMessage(byte[] data);
        void PowerOn();
        void PowerOff();
        void Subscribe();
        void Unsubscribe();
    }
}
