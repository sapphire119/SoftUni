using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var result = MultiplyyEvenbyOdd(number);
            Console.WriteLine(result);
        }

        static int MultiplyyEvenbyOdd(int number)
        {
            var convertedNumber = Convert.ToString(number).Length;
            var sumOfEvens = 0;
            var sumOfOdds = 0;
            for (int i = 0; i < convertedNumber; i++)
            {
                if (number % 2 == 0)
                {
                    sumOfEvens += number % 10;
                    number /= 10;
                }
                else if (number % 2 != 0)
                {
                    sumOfOdds += number % 10;
                    number /= 10;
                }
            }
            var result = sumOfEvens * sumOfOdds;
            return result;

        }
        
    }
}
