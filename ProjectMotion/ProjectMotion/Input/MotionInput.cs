using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMotion.Input
{
    public class MotionInput : MotionIO
    {
        private Dictionary<int, MotionInputHandler> handlers;

        internal MotionInput()
        {
            handlers = new Dictionary<int, MotionInputHandler>();
        }

        public void RegisterHandler(int id,MotionInputHandler handler)
        {
            //Console.WriteLine("MotionInput RegisterHandler id: " + id);
            handlers.Add(id, handler);
        }

        public void DeregisterHandler(int id)
        {
            handlers.Remove(id);
        }

        public T DecodeInput<T>(string Json)
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
    public delegate void MotionInputHandler(string json);
}
