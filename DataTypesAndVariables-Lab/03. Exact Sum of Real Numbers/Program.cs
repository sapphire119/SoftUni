using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = byte.Parse(Console.ReadLine());
            var sum = 0m;
            for (int i = 0; i < number; i++)
            {
                var numberToType = decimal.Parse(Console.ReadLine());
                sum += numberToType;
            }
            Console.WriteLine(sum);
        }
    }
}
