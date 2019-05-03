using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Зад_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            var dots = (input - 2) / 2;
            var dots2 = 0;


            for (int i = 1; i <= input / 2; i++)
            {
                Console.Write(new string('.', dots));
                for (int j = 1; j <= i; j++)
                {
                    if (j % 2 != 0)
                    {
                        Console.Write("/");
                    }
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                }
                for (int j = i; j >= 1; j--)
                {
                    if (j % 2 != 0)
                    {
                        Console.Write("\\");
                    }
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write(new string('.', dots));
                dots -= 1;
                Console.WriteLine();

            }
            for (int i = input/2; i >= 1; i--)
            {
                Console.Write(new string('.', dots2));
                for (int j = 1; j <= i; j++)
                {
                    if (j % 2 != 0)
                    {
                        Console.Write("\\");
                    }
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                }
                for (int j = i; j >= 1; j--)
                {
                    if (j % 2 != 0)
                    {
                        Console.Write("/");
                    }
                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write(new string('.', dots2));
                dots2 += 1;
                Console.WriteLine();

            }


        }
    }
}
