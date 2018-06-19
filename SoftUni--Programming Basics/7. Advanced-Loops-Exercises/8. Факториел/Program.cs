using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Факториел
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int faktoriel=1;
            for (int i = 1; i <= n; i++)
            {

                faktoriel *= i;
            }
            Console.WriteLine(faktoriel);

        }
    }
}
