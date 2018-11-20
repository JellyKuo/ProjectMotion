using InTheHand.Devices.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMotion.Control;

namespace ProjectMotion
{
    public class MotionEngine
    {
        private BluetoothAgent btAgent;

        public MotionEngine()
        {
            btAgent = new BluetoothAgent();
        }

        public void PickDevice()
        {
            var deviceInfo = btAgent.PickSingleDevice();
            var motionDevice = new MotionDevice(deviceInfo);
        }

        public List<MotionDevice> ListDevices()
        {
            var btDevices = btAgent.GetDevices();
            var motionDevices = new List<MotionDevice>();
            foreach (var btDevice in btDevices)
            {
                var motionDevice = new MotionDevice(btDevice);
                motionDevices.Add(motionDevice);
            }
            return motionDevices;
        }

        public bool ConnectToDevice(MotionDevice device)
        {
            var connectionResult = btAgent.Connect(device.deviceInfo);
            if (!connectionResult)
                return false;
            this.Initialize();
            return true;
        }

        internal void SendData(byte[] Payload)
        {
            btAgent.SendData(Payload);
        }
    }
}
