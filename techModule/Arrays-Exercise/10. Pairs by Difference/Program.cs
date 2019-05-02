using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var number = int.Parse(Console.ReadLine());
            var pairs = 0;
            var bestpairAmmount = int.MinValue;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if ((input[i]-input[j])==number)
                    {
                        pairs++;
                    }
                    if (bestpairAmmount < pairs) 
                    {
                        bestpairAmmount = pairs;
                    }
                }
            }
            Console.WriteLine(bestpairAmmount);

        }
    }
}
