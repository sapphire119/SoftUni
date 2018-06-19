using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Перфектен_диамант
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                Console.Write(new string(' ', input - i));
                Console.Write("*");
                for (int j = 2; j <= i; j++)
                {
                    Console.Write("-*");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= input-1; i++)
            {
                Console.Write(new string(' ',i));
                Console.Write("*");
                for (int k =input-i ; k >1; k--)
                {
                    Console.Write("-*");
                }
                Console.WriteLine();
            }


        }
    }
}
