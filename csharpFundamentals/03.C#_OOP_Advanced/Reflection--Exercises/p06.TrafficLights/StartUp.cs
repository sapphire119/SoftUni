using System;

namespace p06.TrafficLights
{
    public class StartUp
    {
        public static void Main()
        {
            IReadable readable = new Reader();
            IWriteable writeable = new Writer();
            Engine engine = new Engine(readable, writeable);
            engine.Run();
        }
    }
}
