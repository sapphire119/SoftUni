using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_3_Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            double length = (wingFlaps / 1000.0) * distance;

            int timeHornetFlaps = wingFlaps / 100;
            int timeHornetRest = (wingFlaps/ endurance)*5;

            int totalTime = timeHornetRest + timeHornetFlaps;

            Console.WriteLine("{0:f2} m.",length);
            Console.WriteLine("{0} s.",totalTime);


        }
    }
}
