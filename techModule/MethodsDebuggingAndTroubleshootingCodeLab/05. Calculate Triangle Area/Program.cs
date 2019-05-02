using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Calculate_Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var area = GetAreaOfTriangle(width, height);
            Console.WriteLine(area);
        }

        static double GetAreaOfTriangle(double width, double height)
        {
            var areaOfTriangle = (width * height) / 2.0;
            return areaOfTriangle;
        }
    }
}
