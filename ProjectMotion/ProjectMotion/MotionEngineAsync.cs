using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    public partial class MotionEngine
    {
        /// <summary>
        /// Prompts user to pick a paired bluetooth device using built-in UI
        /// </summary>
        /// <returns>A MotionDevice user picked</returns>
        public async Task<MotionDevice> BeginPickDevice()
        {
            return await Task.Run(() => PickDevice());
        }

        /// <summary>
        /// Get a list of paired bluetooth device
        /// Use the returned MotionDevice to be the parameter of ConnectToDevice
        /// </summary>
        /// <returns>A list of already paired device</returns>
        public async Task<List<MotionDevice>> BeginListDevices()
        {
            return await Task.Run(() => ListDevices());
        }

        /// <summary>
        /// Connect and initialize a MotionDevice
        /// </summary>
        /// <param name="device">The device to connect to, use ListDevices() to get the devices</param>
        /// <returns>Connection result</returns>
        public async Task<bool> BeginConnectToDevice(MotionDevice device)
        {
            return await Task.Run(() => ConnectToDevice(device));
        }

        /// <summary>
        /// Send data payload to the connected device
        /// </summary>
        /// <param name="Payload">The data to send</param>
        internal async void BeginSendData(Byte[] Payload)
        {
            await Task.Run(() => SendData(Payload));
        }
    }
}
