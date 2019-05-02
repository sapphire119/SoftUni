using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps = 0.000001;
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double diffrence = 0.0;
            double max = Math.Max(firstNumber, secondNumber);
            double min = Math.Min(firstNumber, secondNumber);
            max = max / eps;
            min = min / eps;
            diffrence = max - min;
            if (diffrence>=1)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }



        }
    }
}
