using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = BigInteger.Parse(Console.ReadLine());
            BigInteger sum = 1;
            for (int i = 1; i <=input; i++)
            {
                sum *= i;
            }
            Console.WriteLine(sum);
        }
    }
}
