using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var p = input.Length / 4;
            var leftSide = new int[p];
            var middleSide = new int[2 * p];
            var rightside = new int[p];
            var sum = new int[2 * p];


            for (int i = 0; i < p; i++)
            {
                leftSide[i] += input[i];
            }
            for (int i = 0; i < p; i++)   
            {
                rightside[i] += input[(3 * p) + i];
            }
            for (int i = 0; i < (input.Length - 2 * p); i++)  
            {
                middleSide[i] += input[p + i];
            }
            Array.Reverse(leftSide);
            Array.Reverse(rightside);
            for (int i = 0; i < p; i++)
            {
                sum[i] += leftSide[i] + middleSide[i];
                sum[i+p] += middleSide[i + p] + rightside[i];
            }
            Console.WriteLine(string.Join(" ",sum));

        }
    }
}
