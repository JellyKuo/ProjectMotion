using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion.Input
{
    /// <summary>
    /// Motion Input class, use MotionEngine.Input to get instance
    /// </summary>
    public class MotionInput : MotionIO
    {
        private Dictionary<int, MotionInputHandler> handlers;

        internal MotionInput()
        {
            handlers = new Dictionary<int, MotionInputHandler>();
        }

        /// <summary>
        /// Register a handler for a Motion Input
        /// </summary>
        /// <param name="id">ID of the Input</param>
        /// <param name="handler">The Motion Input Delegate to call when triggered</param>
        public void RegisterHandler(int id,MotionInputHandler handler)
        {
            //Console.WriteLine("MotionInput RegisterHandler id: " + id);
            handlers.Add(id, handler);
        }

        /// <summary>
        /// Removes a registred handler for a Motion Input
        /// </summary>
        /// <param name="id">ID of the Input</param>
        public void DeregisterHandler(int id)
        {
            handlers.Remove(id);
        }

        /// <summary>
        /// Decode a Motion Input Json to a Motion Input Type
        /// </summary>
        /// <typeparam name="T">The Motion Type to deserialize to</typeparam>
        /// <param name="Json">The Json string to parse</param>
        /// <returns>The deserialized object</returns>
        public new T DecodeInput<T>(string Json)
        {
            return base.DecodeInput<T>(Json);
        }

        internal void ReceiveData(string Data)
        {
            //Console.WriteLine("MotionInput ReceiveData");
            int id = GetPayloadId(Data);
            //Console.WriteLine("MotionInput Id: " + id);
            if (!handlers.ContainsKey(id))
            {
                Console.WriteLine("MotionInput No handler found with ID");
                return;
            }
            //Console.WriteLine("MotionInput Invoke delegate...");
            handlers[id](Data);
        }

    }

    /// <summary>
    /// Delegate for Motion Input
    /// </summary>
    /// <param name="json">The received Json string</param>
    public delegate void MotionInputHandler(string json);
}
