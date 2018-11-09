using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    public class MotionDevice
    {
        public string MAC { get; private set; }
        public string Name { get; private set; }

        public MotionDevice(string MAC,string Name)
        {
            this.MAC = MAC;
            this.Name = Name;
        }
    }
}
