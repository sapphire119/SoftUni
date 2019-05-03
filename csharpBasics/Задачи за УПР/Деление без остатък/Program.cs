using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Деление_без_остатък
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int p1, p2, p3;
            p1 = p2 = p3 = 0;
            for (int i = 0; i < n; i++)
            {
                int k = int.Parse(Console.ReadLine());
                if (k%2==0)
                {
                    p1 += 1;
                }
                if (k%3==0)
                {
                    p2 += 1;
                }
                if (k%4==0)
                {
                    p3 += 1;
                }
            }
            Console.WriteLine("{0:f2}%",p1*100/(double)n);
            Console.WriteLine("{0:f2}%", p2 * 100 / (double)n);
            Console.WriteLine("{0:f2}%", p3 * 100 / (double)n);
        }
    }
}
