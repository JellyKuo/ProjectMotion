using InTheHand.Devices.Bluetooth;
using InTheHand.Devices.Enumeration;
using InTheHand.Devices.Bluetooth.Rfcomm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectMotion
{
    internal class BluetoothAgent
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private BluetoothDevice device;
        private Stream stream;
        private readonly string SerialAQS = RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort);
        public bool Connected
        {
            get
            {
                return stream != null && device?.ConnectionStatus == BluetoothConnectionStatus.Connected;
            }
        }

        public BluetoothAgent()
        {

        }

        public DeviceInformation PickSingleDevice()
        {
            var devicePicker = new DevicePicker();
            var deviceInfo = devicePicker.PickSingleDevice();
        }

        public List<DeviceInformation> GetDevices()
        {
            var deviceInformations = new List<DeviceInformation>();
            foreach (var deviceInfo in DeviceInformation.FindAll(SerialAQS))
            {
                deviceInformations.Add(deviceInfo);
            }
            return deviceInformations;
        }

        public DevicePairingResult Pair(DeviceInformation device, string PIN = "1234")
        {
            return device.Pairing.Pair();
        }

        public bool Connect(DeviceInformation deviceInfo)
        {
            device = BluetoothDevice.FromDeviceInformation(deviceInfo);
            var rfSvcsRes = device.GetRfcommServices(BluetoothCacheMode.Cached);
            foreach (var svc in rfSvcsRes.Services)
            {
                if (svc.ServiceId == RfcommServiceId.SerialPort)
                {
                    stream = svc.OpenStream();
                    break;
                }
            }
            return stream != null;
        }

        public void SendData(byte[] data)
        {
            logger.Trace("SendData Payload: {data}", data);
            stream.Write(data, 0, data.Length);
        }

        public void SendData(string s)
        {
            SendData(Encoding.ASCII.GetBytes(s));
        }

        public string Read()
        {
            byte[] buffer = new byte[256];
            string data = "";
            int i = 0;
            while (stream.CanRead && (i = stream.Read(buffer, 0, 256)) > 0)
            {
                data += Encoding.UTF8.GetString(buffer, 0, i);
            }
            data += "\r\n";
            return data;
        }
    }
}
