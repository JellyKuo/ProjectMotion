using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    public class MotionCapability
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        CapabilityType CapabilityType { get; set; }

    }

    public enum CapabilityType
    {
        Input,Output
    }
}
