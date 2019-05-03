using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Най_малко_число
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiChisla = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            for (int i = 0; i < broiChisla; i++)
            {
                int k = int.Parse(Console.ReadLine());
                if (min>k)
                {
                    min = k++;
                }
            }
            Console.WriteLine(min);

        }
    }
}
