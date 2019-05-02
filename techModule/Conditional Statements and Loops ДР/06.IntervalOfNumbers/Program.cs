using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = int.Parse(Console.ReadLine());
            var input2 = int.Parse(Console.ReadLine());

            var maximum = Math.Max(input1, input2);
            var minimum = Math.Min(input1, input2);
            Console.WriteLine();
            for (int i = minimum; i <= maximum; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
