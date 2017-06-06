using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var x3 = double.Parse(Console.ReadLine());
            var y3 = double.Parse(Console.ReadLine());
            var x4 = double.Parse(Console.ReadLine());
            var y4 = double.Parse(Console.ReadLine());
            PrintTheLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }

        static void PrintTheLongerLine(
            double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            var sideX1X2 = Math.Abs(x1 - x2);
            var heightY1Y2 = Math.Abs(y1 - y2);
            decimal lineX1X2Y1Y2 = (decimal)Math.Sqrt(Math.Pow(sideX1X2, 2) + Math.Pow(heightY1Y2, 2));

            var sideX3X4 = Math.Abs(x3 - x4);
            var heightY3Y4 = Math.Abs(y3 - y4);
            var lineX3X4Y3Y4 = (decimal)Math.Sqrt(Math.Pow(sideX3X4, 2) + Math.Pow(heightY3Y4, 2));
            if (lineX1X2Y1Y2 >= lineX3X4Y3Y4)
            {
                PrintPointClosestToCenter(x1, y1, x2, y2);
            }
            else
            {
                PrintPointClosestToCenter(x3, y3, x4, y4);
            }
        }

        static void PrintPointClosestToCenter(double x1, double y1, double x2, double y2)
        {
            decimal diagonalX1Y1 = (decimal)Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            decimal diagonalX2Y2 = (decimal)Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            if (diagonalX1Y1 <= diagonalX2Y2)
            {
                Console.WriteLine("({0}, {1})({2}, {3})", x1, y1,x2,y2);
            }
            else if (diagonalX1Y1 > diagonalX2Y2)
            {
                Console.WriteLine("({0}, {1})({2}, {3})", x2, y2,x1,y1);
            }
        }
    }
}

