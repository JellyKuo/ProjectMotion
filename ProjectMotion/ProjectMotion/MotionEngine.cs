using InTheHand.Devices.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMotion.Control;

namespace ProjectMotion
{
    /// <summary>
    /// MotionEngine base class
    /// </summary>
    public partial class MotionEngine
    {
        private BluetoothAgent btAgent;
        public Input.MotionInput Input;
        private MotionState _State;

        public MotionState State
        {
            get
            {
                return _State;
            }
        }
        

        /// <summary>
        /// Initialize a new MotionEngine
        /// </summary>
        public MotionEngine()
        {
            btAgent = new BluetoothAgent();
            btAgent.OnReceiveData = new BluetoothAgent.ReceiveDataHandler(ReadData);
            Input = new Input.MotionInput();
        }

        /// <summary>
        /// Prompts user to pick a paired bluetooth device using built-in UI
        /// </summary>
        /// <returns>MotionDevice user picked</returns>
        public MotionDevice PickDevice()
        {
            var deviceInfo = btAgent.PickSingleDevice();
            var motionDevice = new MotionDevice(deviceInfo);
            return motionDevice;
        }

        /// <summary>
        /// <para>Get a list of paired bluetooth device</para>
        /// Use the returned MotionDevice to be the parameter of ConnectToDevice
        /// </summary>
        /// <returns>A list of already paired device</returns>
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

        /// <summary>
        /// Connect and initialize a MotionDevice
        /// </summary>
        /// <param name="device">The device to connect to, use ListDevices() to get the devices</param>
        /// <returns>Connection result</returns>
        public bool ConnectToDevice(MotionDevice device)
        {
            var connectionResult = btAgent.Connect(device.deviceInfo);
            if (!connectionResult)
                return false;
            return true;
        }

        public void BeginInput()
        {
            Console.WriteLine("ENGINE BeginRead");
            this.SetRead(true);
            btAgent.StartRead();
        }

        public void StopInput()
        {
            Console.WriteLine("ENGINE StopRead");
            btAgent.StopRead();
            this.SetRead(false);
            btAgent.ResetStream();
        }

        /// <summary>
        /// Send data payload to the connected device
        /// </summary>
        /// <param name="Payload">The data to send</param>
        internal void SendData(byte[] Payload)
        {
            btAgent.SendData(Payload);
        }

        internal void ReadData(string Data)
        {
            Console.WriteLine("ENGINE ReceiveData");
            Input.ReceiveData(Data);
        }

    }
}
