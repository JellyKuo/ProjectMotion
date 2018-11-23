using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    public partial class MotionEngine
    {
        public async Task<MotionDevice> BeginPickDevice()
        {
            return await Task.Run(() => PickDevice());
        }

        public async Task<List<MotionDevice>> BeginListDevices()
        {
            return await Task.Run(() => ListDevices());
        }

        public async Task<bool> BeginConnectToDevice(MotionDevice device)
        {
            return await Task.Run(() => ConnectToDevice(device));
        }

        internal async void BeginSendData(Byte[] Payload)
        {
            await Task.Run(() => SendData(Payload));
        }
    }
}
