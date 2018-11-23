using InTheHand.Devices.Bluetooth;
using InTheHand.Devices.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    /// <summary>
    /// Device representation for MotionEngine
    /// </summary>
    public class MotionDevice
    {
        internal DeviceInformation deviceInfo;
        /// <summary>
        /// Device's friendly name
        /// </summary>
        public string Name
        {
            get
            {
                return deviceInfo.Name;
            }
        }
        /// <summary>
        /// Device's ID
        /// </summary>
        public string Id
        {
            get
            {
                return deviceInfo.Id;
            }
        }
        private string _Address = null;
        /// <summary>
        /// Address of the device
        /// </summary>
        public string Address
        {
            get
            {
                if (_Address == null)
                    _Address = Id.Replace("BLUETOOTH#", "");
                return _Address;
            }
        }

        internal MotionDevice(DeviceInformation deviceInfo)
        {
            this.deviceInfo = deviceInfo;
        }
    }
}
