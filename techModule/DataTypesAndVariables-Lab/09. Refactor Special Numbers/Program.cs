using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int num = 1; num <= input; num++)
            {
                int sum = 0;
                int current = num;
                while (current > 0)
                {
                    sum += current % 10;
                    current/= 10;
                }
                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {isSpecial}");
            }

        }
    }
}
