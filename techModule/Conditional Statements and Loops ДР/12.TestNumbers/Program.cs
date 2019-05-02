using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            var stopNumber = int.Parse(Console.ReadLine());
            var sum = 0.0;
            var iterator = 0;
            for (int i = input; i >= 1; i--)
            {
                for (int j = 1; j <= second; j++)
                {
                    iterator++;
                    sum += (3 * (i * j));
                    if (sum>=stopNumber)
                    {
                        Console.WriteLine($"{iterator} combinations");
                        Console.WriteLine($"Sum: {sum} >= {stopNumber}");
                        return;
                    }
                }
            }
            if (sum <=stopNumber)
            {
                Console.WriteLine($"{iterator} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
