using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    internal class BluetoothAgent
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private BluetoothClient client;
        private NetworkStream stream;
        public bool Connected
        {
            get
            {
                return client.Connected;
            }
        }

        public BluetoothAgent()
        {
            logger.Debug("Constructed");
            client = new BluetoothClient();
        }

        public BluetoothDeviceInfo[] GetDevices()
        {
            logger.Debug("GetDevices");
            var devices = client.DiscoverDevices();
            return devices;
        }

        public bool Pair(string MAC, string PIN = "1234")
        {
            logger.Debug("Pair with MAC address {MAC} and PIN {PIN}",MAC,PIN);
            var d = new BluetoothDeviceInfo(BluetoothAddress.Parse(MAC));
            return BluetoothSecurity.PairRequest(d.DeviceAddress, PIN);
        }

        public bool Connect(string MAC)
        {
            logger.Debug("Connect with MAC address {MAC}", MAC);
            var ep = new BluetoothEndPoint(BluetoothAddress.Parse(MAC), BluetoothService.SerialPort);
            client.Connect(ep);
            stream = client.GetStream();
            SendData("CONNECT");
            var response = Read();
            logger.Debug("Connect response: {response}", response);
            return response == "OK";
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
            while (stream.DataAvailable && (i = stream.Read(buffer, 0, 256)) > 0)
            {
                data += Encoding.UTF8.GetString(buffer, 0, i);
            }
            data += "\r\n";
            return data;
        }
    }
}
