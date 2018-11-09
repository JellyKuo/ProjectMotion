﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion.Feedback
{
    class Vibrate : MotionIO
    {
        public readonly int ID = 0x0001;
        [JsonIgnoreAttribute]
        public readonly string Name = "Vibrate";

        public Vibrate(int Intensity)
        {
            this.Intensity = Intensity;
        }
        public int Intensity { get; set; }
        
    }

    public static partial class FeedbackExtensions
    {
        public static void Vibrate(this MotionEngine Engine, int Intensity)
        {
            var vibrate = new Vibrate(Intensity);
            var Payload = vibrate.EncodePayload();
            Engine.SendData(Payload);
        }
    }
}
