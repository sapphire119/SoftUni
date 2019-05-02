using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int num = 2; num <= input; num++)
            {
                int broiDeleneta = 0;
                for (int delitel = 2; delitel <= num; delitel++)
                {
                    if (num % delitel ==0)
                    {
                        broiDeleneta++;
                    }
                    //За да е просто трябва да се дели и на себе си 
                    
                }
                bool isitPrime = (broiDeleneta == 1);
                Console.WriteLine($"{num} -> {isitPrime}");
            }

        }
    }
}
