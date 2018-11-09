using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion.Input
{
    class Gyro : MotionIO
    {
        public readonly int ID = 0xf001;
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public readonly string Name = "Gyroscope";
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }


}
