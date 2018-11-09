using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    abstract class MotionIO
    {
        public virtual byte[] EncodePayload()
        {
            string output = JsonConvert.SerializeObject(this);
            return Encoding.ASCII.GetBytes(output);
        }
    }
}
