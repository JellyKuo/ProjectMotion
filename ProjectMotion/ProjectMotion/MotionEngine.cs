using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    public class MotionEngine
    {
        private BluetoothAgent btAgent;

        public MotionEngine()
        {
            btAgent = new BluetoothAgent();
        }

        public List<MotionDevice> ListDevices()
        {
            var btDevices = btAgent.GetDevices();
            var motionDevices = new List<MotionDevice>();
            foreach (var btDevice in btDevices)
            {
                var motionDevice = new MotionDevice(btDevice.DeviceAddress.ToString(), btDevice.DeviceName);
                motionDevices.Add(motionDevice);
            }
            return motionDevices;
        }

        public bool ConnectToDevice(MotionDevice device)
        {
            btAgent.Pair(device.MAC); // TODO: Implement PIN code
            return btAgent.Connect(device.MAC);
        }

        internal void SendData(byte[] Payload)
        {
            btAgent.SendData(Payload);
        }
    }
}
