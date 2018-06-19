using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            var numb1 = double.Parse(Console.ReadLine());
            var numb2 = double.Parse(Console.ReadLine());
            var sum = numb1 * numb2;
            Console.WriteLine($"{sum:f2}");

        }
    }
}
