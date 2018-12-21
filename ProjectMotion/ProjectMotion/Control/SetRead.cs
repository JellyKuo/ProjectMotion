using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectMotion.Control
{
    class SetRead : MotionIO
    {
        public readonly int id = 0x0002;
        [JsonIgnoreAttribute]
        public readonly string Name = "Initialize";
        public bool state { get; set; }

        public SetRead(bool state)
        {
            this.state = state;
        }
    }

    internal static partial class ControlExtension
    {
        public static void SetRead(this MotionEngine Engine,bool State)
        {
            var setRead = new SetRead(State);
            var Payload = setRead.EncodePayload();
            Engine.BeginSendData(Payload);
        }
    }
}