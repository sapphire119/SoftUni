using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FiveDiffrentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());

            for (int i = input; i <= second - 4; i++)
            {
                for (int j = input + 1; j <= second - 3; j++)
                {
                    for (int k = input + 2; k <= second - 2; k++)
                    {
                        for (int h = input + 3; h <= second - 1; h++)
                        {
                            for (int p = input + 4; p <= second; p++)
                            {
                                if (input <= i && i < j && j < k && k < h && h < p && h <= second)
                                {
                                    Console.WriteLine("{0} {1} {2} {3} {4}", i, j, k, h, p);
                                }
                            }
                        }
                    }
                }
            }
            if ((second -input) <5)
            {
                Console.WriteLine("No");
            }



        }
    }
}
