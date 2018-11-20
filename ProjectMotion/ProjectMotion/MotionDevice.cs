using InTheHand.Devices.Bluetooth;
using InTheHand.Devices.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    public class MotionDevice
    {
        internal DeviceInformation deviceInfo;
        public string Name
        {
            get
            {
                return deviceInfo.Name;
            }
        }
        public string Id
        {
            get
            {
                return deviceInfo.Id;
            }
        }
        private string _Address = null;
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
