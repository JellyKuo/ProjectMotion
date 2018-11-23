using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion.Control
{
    class Initialize : MotionIO
    {
        public readonly int id = 0x0001;
        [JsonIgnoreAttribute]
        public readonly string Name = "Initialize";

        public Initialize()
        {

        }
    }

    internal static partial class ControlExtension
    {
        public static void Initialize(this MotionEngine Engine)
        {
            var initialize = new Initialize();
            var Payload = initialize.EncodePayload();
            Engine.BeginSendData(Payload);
        }
    }
}
