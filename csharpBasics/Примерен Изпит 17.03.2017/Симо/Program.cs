using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_of_two_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNum = int.Parse(Console.ReadLine());
            var lastNum = int.Parse(Console.ReadLine());
            var margicNum = int.Parse(Console.ReadLine());

            var sum = 0;
            var combinations = Math.Pow((lastNum - firstNum + 1), 2);
            var result = 0;
            var count = 0;

            var firstNumNeeded = 0;
            var lastNumNeeded = 0;

            for (int i = (lastNum - firstNum + 1); i >= firstNum; i--)
            {
                for (int j = (lastNum - firstNum + 1); j >= firstNum; j--)
                {
                    count++;
                    sum = firstNum + lastNum;
                    if (sum == margicNum)
                    {
                        result = count;
                        firstNumNeeded = firstNum;
                        lastNumNeeded = lastNum;
                    }
                    lastNum--;
                }
                firstNum--;
            }

            if (result != 0)
            {
                Console.WriteLine("Combination N:{0} ({1} + {2} = {3})", result, firstNumNeeded, lastNumNeeded, margicNum);
            }
            else
            {
                Console.WriteLine("{0} combinations - neuther equals {1}", combinations);
            }
        }
    }
}
