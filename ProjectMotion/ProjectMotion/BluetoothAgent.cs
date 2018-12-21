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
using System.Threading;

namespace ProjectMotion
{
    internal class BluetoothAgent
    {
        private BluetoothDevice device;
        private Stream stream;
        private readonly string SerialAQS = RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort);
        private CancellationTokenSource cancellationTkSrc;
        private Thread readTaskThread;

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
            return deviceInfo;
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
            return Connect(device);
        }

        public bool Connect(BluetoothDevice device = null)
        {
            if (device == null)
                device = this.device;
            var rfSvcsRes = device.GetRfcommServices(BluetoothCacheMode.Uncached);
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
            stream.Write(data, 0, data.Length);
        }

        public void SendData(string s)
        {
            SendData(Encoding.ASCII.GetBytes(s));
        }

        public void StartRead()
        {
            if (!Connected)
            {
                throw new InvalidOperationException("MotionEngine is not connected to any device.");
            }
            cancellationTkSrc = new CancellationTokenSource();
            var cancellationTk = cancellationTkSrc.Token;

            Task.Factory.StartNew(() =>
            {
                readTaskThread = Thread.CurrentThread;
                while (!cancellationTk.IsCancellationRequested)
                {
                    //byte[] buffer = new byte[256];
                    //int i = 0;
                    //Console.WriteLine("READ");
                    //i = stream.Read(buffer, 0, 256);
                    //string data = Encoding.UTF8.GetString(buffer, 0, i);
                    //Console.WriteLine($"Data length: {i}  received: {data}");

                    byte[] length = new byte[1];
                    //Console.WriteLine("READ");
                    stream.Read(length,0,1);
                    Console.WriteLine($"Length: {length[0]:x}");
                    int i = 0;
                    byte[] buffer = new byte[64];
                    string data = "";
                    while(length[0] > i)
                    {
                        buffer = new byte[64];
                        int partLength = stream.Read(buffer, 0, 64);
                        i += partLength;
                        data += Encoding.ASCII.GetString(buffer, 0, partLength);
                        //Console.WriteLine($"READ PART I:{i} DATA:{data} PL:{partLength}");
                    }
                    //Console.WriteLine($"READ FINISHED, DATA: {data}");
                    OnReceiveData(data);
                }
                Console.WriteLine("Task cancelled");
            }, cancellationTk);
        }

        public void StopRead()
        {
            if (cancellationTkSrc == null)
            {
                throw new InvalidOperationException("Stream is not reading!");
            }
            cancellationTkSrc.Cancel();
            readTaskThread.Abort();
        }

        public void ResetStream()
        {
            stream.Flush();
            stream.Dispose();
            Task.Delay(500).ContinueWith((t) => Connect());
        }

        public delegate void ReceiveDataHandler(string data);
        public ReceiveDataHandler OnReceiveData;
    }
}
