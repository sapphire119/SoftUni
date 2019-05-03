using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blaa
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputSize = int.Parse(Console.ReadLine());

            if (inputSize == 0)
                Console.WriteLine("OddSum=0, OddMin=no, OddMax=no, EvenSum=0, EvenMin=No, EvenMax=No");

            double sumOfOddNums, sumOfEvenNums;
            double minOddNum, maxOddNum;
            double minEvenNum, maxEvenNum;

            sumOfOddNums = sumOfEvenNums = 0;
            minOddNum = minEvenNum = double.MaxValue;
            maxOddNum = maxEvenNum = double.MinValue;

            for (int i = 1; i <= inputSize; ++i)
            {
                double input = double.Parse(Console.ReadLine());

                if (inputSize <= 1)
                {
                    Console.WriteLine("OddSum={0}, OddMin={0}, OddMax={0}, EvenSum=0, EvenMin=No, EvenMax=No", input);
                }

                if (i % 2 == 0)
                {
                    sumOfEvenNums += input;

                    if (input < minEvenNum)
                        minEvenNum = input;

                    if (input > maxEvenNum)
                        maxEvenNum = input;
                }

                else
                {
                    sumOfOddNums += input;

                    if (input < minOddNum)
                        minOddNum = input;

                    if (input > maxOddNum)
                        maxOddNum = input;
                }
            }

            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                              sumOfOddNums, minOddNum, maxOddNum, sumOfEvenNums, minEvenNum, maxEvenNum);
        }
    }

}
    

    

