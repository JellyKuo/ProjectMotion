using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    /// <summary>
    /// Represent a function MotionDevice is capable of
    /// </summary>
    public class MotionCapability
    {
        /// <summary>
        /// The friendly name of the function
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Function ID
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Type of capability
        /// </summary>
        CapabilityType CapabilityType { get; set; }

    }

    /// <summary>
    /// Motion device's capability types
    /// </summary>
    public enum CapabilityType
    {
        /// <summary>
        /// Represent the capability is a input to the host application
        /// </summary>
        Input,
        /// <summary>
        /// Represent the capability is a output of the host application
        /// </summary>
        Output
    }
}
