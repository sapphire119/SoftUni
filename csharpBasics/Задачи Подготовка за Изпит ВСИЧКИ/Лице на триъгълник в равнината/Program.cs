using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лице_на_триъгълник_в_равнината
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());
            int max, min, max1, min1;
            max = Math.Max(x2, x3);
            min = Math.Min(x2, x3);
            max1 = Math.Max(y1, y3);
            min1 = Math.Min(y1, y3);

            if (y2==y3)
            {
                double a, h, S;
                a = h = S = 0;
                a = max - min;
                h = max1 - min1;
                S = a * h /2.0;
                Console.WriteLine("{0}",S);
            }
            



        }
    }
}
