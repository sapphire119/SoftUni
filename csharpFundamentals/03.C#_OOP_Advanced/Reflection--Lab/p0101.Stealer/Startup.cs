namespace p0101.Stealer
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Spy spy = new Spy();
            spy.Courses = Courses.FrontEnd;
            if (spy.Courses.HasFlag(Courses.JS) && spy.Courses.HasFlag(Courses.Web))
            {
                Console.WriteLine("Front End");
            }
        }
    }
}
