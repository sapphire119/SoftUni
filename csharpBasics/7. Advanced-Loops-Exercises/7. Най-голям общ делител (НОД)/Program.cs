using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Най_голям_общ_делител__НОД_
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (a == b)
            {
                Console.WriteLine(a);
            }
            else
            {
                int newDivisor = 1;
                int big = Math.Max(a, b);
                int small = Math.Min(a, b);
                int diffrence = big - small;
                int iterator = Math.Min(diffrence, small);
                for (int i = 1; i <= iterator; i++)
                {
                    if (diffrence % i == 0 && small % i == 0)
                    {
                        newDivisor = i;
                    }

                }
                Console.WriteLine(newDivisor);
            }
        }
    }
}
