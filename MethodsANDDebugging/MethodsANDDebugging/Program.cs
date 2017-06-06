using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());
            bool isitPrime = IsPrime(input);
            Console.WriteLine(isitPrime);
        }

        private static bool IsPrime(long input)
        {

            var boundary = (int)Math.Floor(Math.Sqrt(input));
            if (input == 0 || input == 1) return false;   
            if (input == 2) return true;

            for (int i = 2; i <= boundary; i++)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }

            return true;    
        }
    }
}
