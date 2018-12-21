using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion.Input
{
    public class Gyro : MotionIO
    {
        public static readonly int id = 0xf001;
        [Newtonsoft.Json.JsonIgnore]
        public readonly string Name = "Gyroscope";
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        
    }
}
