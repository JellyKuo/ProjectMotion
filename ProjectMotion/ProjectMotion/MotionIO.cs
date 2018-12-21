using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion
{
    /// <summary>
    /// An abstract underlying layer for all Motion Inputs and Feedbacks
    /// </summary>
    public abstract class MotionIO
    {
        internal virtual T DecodeInput<T>(string Json)
        {
            return JsonConvert.DeserializeObject<T>(Json);
        }

        internal virtual byte[] EncodePayload()
        {
            string output = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(output);
        }

        internal virtual int GetPayloadId(string jsonString)
        {
            JObject jObj = JObject.Parse(jsonString);
            int id = jObj.Value<int>("id");
            return id;
        }

    }
}
