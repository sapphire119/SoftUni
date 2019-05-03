using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Къщичка
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int broi = 0;
            if (n % 2 != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    
                    if (i % 2 != 0)
                    {
                        broi += 1;
                        for (int c = 1; c <= (n - i) / 2; c++)
                        {
                               Console.Write("-");
                        }
                        for (int j = 1; j <= i; j++)
                        {
                                Console.Write("*", j);
                        }
                        for (int c = 1; c <= (n - i) / 2; c++)
                        {
                                Console.Write("-");
                        }
                           Console.WriteLine();
                    }
                }
                int diffrence = n - broi;
                for (int k = 0; k < diffrence; k++)
                {
                    Console.Write("|");
                    for (int l = 1; l <=n-2; l++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
                
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {

                    if (i % 2 == 0)
                    {
                        broi += 1;
                        for (int c = 1; c <= (n - i) / 2; c++)
                        {
                            Console.Write("-");
                        }
                        for (int j = 1; j <= i; j++)
                        {
                            Console.Write("*", j);
                        }
                        for (int c = 1; c <= (n - i) / 2; c++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();
                    }
                }
                int diffrence = n - broi;
                for (int k = 0; k < diffrence; k++)
                {
                    Console.Write("|");
                    for (int l = 1; l <= n - 2; l++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }

            }

        }
    }
}
