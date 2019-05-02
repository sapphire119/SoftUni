using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MegaPixels
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());

            double sum = input * second;
            sum = sum / 1000000.0;
            sum = Math.Round(sum, 1);

            Console.WriteLine($"{input}x{second} => {sum}MP");
        }
    }
}
