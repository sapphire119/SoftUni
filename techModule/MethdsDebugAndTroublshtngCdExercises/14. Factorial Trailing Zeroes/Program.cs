using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _14.Factorial_Trailing_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = BigInteger.Parse(Console.ReadLine());
            BigInteger sum = 1;
            for (int i = 1; i <= input; i++)
            {
                sum *= i;
            }
            var result = ContainsZero(sum);
            Console.WriteLine(result);

        }

        static int ContainsZero(BigInteger number)
        {
            var iterator = 0;
            byte result = 0;
            while (number > 0)
            {
                result = (byte)(number % 10);
                if (result != 0)
                {
                    return iterator;
                }
                iterator++;
                number /= 10;
                result = 0;
            }
            return iterator;
        }
    }
}
