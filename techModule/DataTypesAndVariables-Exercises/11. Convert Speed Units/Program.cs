using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 mile = 1609m

            int distanceInMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float newSeconds = (hours * 3600f) + (minutes * 60f) + seconds;
            float newHours = newSeconds / 3600f;
            float miles = distanceInMeters / 1609f;

            Console.WriteLine("{0}", (distanceInMeters / newSeconds));
            Console.WriteLine("{0}", ((distanceInMeters / 1000f) / newHours));
            Console.WriteLine("{0}", (miles / newHours));




        }
    }
}
