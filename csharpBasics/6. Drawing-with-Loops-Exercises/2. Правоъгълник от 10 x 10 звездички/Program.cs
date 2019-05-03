using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Правоъгълник_от_10_x_10_звездички
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(new string('*',10));
                //for (int j = 1; j <= 10; j++)
                //{
                //    Console.Write("*");
                //}
                //Console.WriteLine();
            }
        }
    }
}
