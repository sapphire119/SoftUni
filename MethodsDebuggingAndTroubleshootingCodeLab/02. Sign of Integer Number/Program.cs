using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sign_of_Integer_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            PrintSign(number);
        }

        private static void PrintSign(int number)
        {
            if (number <0)
            {
                Console.WriteLine("The number {0} is negative.",number);
            }
            else if (number >0)
            {
                Console.WriteLine("The number {0} is positive.", number);
            }
            else
            {
                Console.WriteLine("The number {0} is zero.", number);
            }
        }
        
    }
}
