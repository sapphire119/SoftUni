using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Rectangle_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthOfRectangle = double.Parse(Console.ReadLine());
            double heightofRectangle = double.Parse(Console.ReadLine());
            double perimeter = (2 * widthOfRectangle) + (2 * heightofRectangle);
            double area = widthOfRectangle * heightofRectangle;
            double diagonal = Math.Pow(widthOfRectangle, 2) + Math.Pow(heightofRectangle, 2);
            diagonal =Math.Sqrt(diagonal);
            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(diagonal);
        }
    }
}
