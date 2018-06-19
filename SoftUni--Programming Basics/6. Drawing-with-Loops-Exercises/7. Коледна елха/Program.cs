using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Коледна_елха
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n+1; i++)
            {
                for (int j = 0; j < (n+1)-i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i-1; k++)
                {
                    Console.Write("*");
                }
                Console.Write(" | ");
                for (int k = 0; k < i-1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }


        }
    }
}
