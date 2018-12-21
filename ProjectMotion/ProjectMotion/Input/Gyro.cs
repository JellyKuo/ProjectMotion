using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion.Input
{
    /// <summary>
    /// Motion Input Gyro
    /// </summary>
     public class Gyro : MotionIO
    {
        /// <summary>
        /// Motion Input ID
        /// </summary>
        public static readonly int id = 0xf001;
        /// <summary>
        /// Name of the input
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public readonly string Name = "Gyroscope";
        /// <summary>
        /// X value of the gyroscope
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y value of the gyroscope
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Z value of the gyroscope
        /// </summary>
        public int Z { get; set; }
        
    }
}
