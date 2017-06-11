using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            CalculateArea(input);
        }

        private static void CalculateArea(string input)
        {
            if (input == "triangle")
            {
                CalculateAreaTriangle();
            }
            else if (input == "square")
            {
                CalculateAreaSquare();
            }
            else if (input == "circle")
            {
                CalculateAreaCircle();
            }
            else if (input == "rectangle")
            {
                CalculateAreaRectangle();
            }
        }

        private static double CalculateAreaRectangle()
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());
            double area = firstNumber * secondNumber;
            Console.WriteLine($"{area:f2}");
            return area;    
        }

        private static double CalculateAreaCircle()
        {
            var firstNumber = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(firstNumber, 2);
            Console.WriteLine($"{area:f2}");
            return area;
        }

        private static double CalculateAreaSquare()
        {
            var firstNumber = double.Parse(Console.ReadLine());
            double area = Math.Pow(firstNumber, 2);
            Console.WriteLine($"{area:f2}");
            return area;
        }

        private static double CalculateAreaTriangle()
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());
            double area = (firstNumber * secondNumber) / 2.0;
            Console.WriteLine($"{area:f2}");
            return area;
        }
    }
}
