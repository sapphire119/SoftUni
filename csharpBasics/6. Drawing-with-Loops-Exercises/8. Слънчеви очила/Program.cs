using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Слънчеви_очила
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                {
                    for (int j = 1; j <= 2 * n; j++)
                    {
                        Console.Write("*");
                    }
                    for (int k = 1; k <= n; k++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 1; j <= 2 * n; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine(); 
                }
                else
                {
                    Console.Write("*");
                    for (int z = 0; z < (2 * n) - 2; z++)
                    {
                        Console.Write("/");
                    }
                    Console.Write("*");
                    if (n < 4 || 2 * i - n == 1 || (n / i == 2 && n % i == 0) )
                    {
                        for (int x = 0; x < n; x++)
                        {
                            Console.Write("|");
                        }
                    }
                    else
                    {
                        for (int x = 0; x < n; x++)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.Write("*");
                    for (int z = 0; z < (2 * n) - 2; z++)
                    {
                        Console.Write("/");
                    }
                    Console.WriteLine("*");
                }

            }
        }
    }
}
