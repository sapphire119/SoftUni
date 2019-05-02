using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberInSequence = int.Parse(Console.ReadLine());

            PrintFibonacciNumber(numberInSequence);
        }

        private static void PrintFibonacciNumber(int numberInSequence)
        {
            long numberOne = 1;
            long numberTwo = 0;
            long sum = 0;
            if (numberInSequence == 0)
            {
                Console.WriteLine("1");return;
            }
            for (int i = 1; i <= numberInSequence; i++)
            {
                sum = numberOne + numberTwo;
                numberTwo = numberOne;
                numberOne = sum;
            }
            Console.WriteLine(sum);
            
        }
    }
}
