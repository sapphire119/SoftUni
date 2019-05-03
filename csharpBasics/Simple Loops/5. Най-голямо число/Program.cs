using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Най_голямо_число
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiChisla = int.Parse(Console.ReadLine());
            int max=int.MinValue;
            for (int i = 0; i < broiChisla; i++)
            {
                int k = int.Parse(Console.ReadLine());
                if (max<k)
                {
                    max =k;
                   
                }
            }
            Console.WriteLine(max);

        }
    }
}
