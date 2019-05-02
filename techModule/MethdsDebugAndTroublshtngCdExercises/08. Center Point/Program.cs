using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            PrintPointClosestToCenter(x1, y1, x2, y2);

        }

        static void PrintPointClosestToCenter(double x1, double y1, double x2, double y2)
        {
            decimal diagonalX1Y1 = (decimal)Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            decimal diagonalX2Y2 = (decimal)Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            if (diagonalX1Y1 < diagonalX2Y2)
            {
                Console.WriteLine("({0}, {1})", x1, y1);
            }
            else if (diagonalX1Y1 > diagonalX2Y2)
            {
                Console.WriteLine("({0}, {1})", x2, y2);
            }
            else
            {
                Console.WriteLine("({0}, {1})", x1, y1);
            }
        }
    }
}
