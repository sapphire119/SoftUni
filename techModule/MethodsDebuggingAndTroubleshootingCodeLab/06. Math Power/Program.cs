using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = double.Parse(Console.ReadLine());
            var power = int.Parse(Console.ReadLine());
            var result = CalculatePowerOfNumber(number, power);
            Console.WriteLine(result);
        }

        static double CalculatePowerOfNumber(double number, int power)
        {
            var result = 1.0;
            for (int i = 1 ; i <= power; i++)
            {
                result *= number;
            }
            return result;

        }
    }
}
