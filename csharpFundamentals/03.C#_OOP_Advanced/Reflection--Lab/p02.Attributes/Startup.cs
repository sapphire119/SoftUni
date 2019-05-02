using System;

namespace p02.Attributes
{
    [SoftUni("Ventsi")]
    public class Startup
    {
        [SoftUni("Gosho")]
        public static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
