using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Ромбче_от_звездички
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n-i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int k = 0; k < i-1; k++)
                {
                    Console.Write(" *");
                    
                }
                Console.WriteLine();
            }
            for (int i = n-1; i >= 1; i--) 
            {
                for (int j = n-i; j >0; j--)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int k = i - 1; k >0; k--)
                {
                    Console.Write(" *");

                }
                Console.WriteLine();

            }
        }
    }
}
