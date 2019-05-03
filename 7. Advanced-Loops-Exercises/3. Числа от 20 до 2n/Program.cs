using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Числа_от_20_до_2n
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i <= input; i++)
            {
                Console.WriteLine("{0}", Math.Pow(2,i));
            }

        }
    }
}
