using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNum = int.Parse(Console.ReadLine());
            var seoncdNum = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(", ", FindPrimesInRange(firstNum, seoncdNum)));
        }

        static List<int> FindPrimesInRange(int firstNum, int seoncdNum)
        {
            var result = new List<int>();
            for (int i = firstNum; i <= seoncdNum; i++)
            {
                if (IsPrime(i))
                {
                    result.Add(i);
                }
            }
            return result;
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
