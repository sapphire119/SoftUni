namespace p08.CreateCustomClassAttribute
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            IWriteable writeable = new Writer();
            IReadable readable = new Reader();

            Engine engine = new Engine(writeable, readable);
            engine.Run();
        }
    }
}
