namespace p03.Ferrari
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var driverName = Console.ReadLine();

            global::Ferrari ferrari = new global::Ferrari(driverName);

            Console.WriteLine(ferrari);
        }
    }
}