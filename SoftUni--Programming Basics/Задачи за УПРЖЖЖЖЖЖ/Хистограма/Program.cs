using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Хистограма
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p1, p2, p3, p4, p5;
            p1 = p2 = p3 = p4 = p5 = 0;
            for (int i = 1; i <= number; i++)
            {
                int k = int.Parse(Console.ReadLine());

                if (k < 200)
                {
                    p1++;
                }
                if (k >= 200 && k <= 399)
                {
                    p2++;
                }
                if (k >= 400 && k <= 599)
                {
                    p3++;
                }
                if (k >= 600 && k <= 799)
                {
                    p4++;
                }
                if (k >= 800)
                {
                    p5++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("{0:f2}%",p1*100/(double)number);
            Console.WriteLine("{0:f2}%", p2 * 100 / (double)number);
            Console.WriteLine("{0:f2}%", p3 * 100 / (double)number);
            Console.WriteLine("{0:f2}%", p4 * 100 / (double)number);
            Console.WriteLine("{0:f2}%", p5 * 100 / (double)number);


        }
        
    }
}
