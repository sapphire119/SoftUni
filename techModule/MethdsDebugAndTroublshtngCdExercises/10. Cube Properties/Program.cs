using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = double.Parse(Console.ReadLine());
            var paramater = Console.ReadLine();
            decimal result =0.0m;
            if (paramater == "face")
            {
                result = CalculatingFaceDiagaonal(input);
            }
            else if (paramater == "space")
            {
                result = CalculatingSpaceDiagaonal(input);
            }
            else if (paramater == "volume")
            {
                result = (decimal)Math.Pow(input, 3);
            }
            else if (paramater == "area")
            {
                result = (decimal)(6 * Math.Pow(input, 2));
            }
            Console.WriteLine($"{result:f2}");

        }

        private static decimal CalculatingSpaceDiagaonal(double input)
        {
            var result = (decimal)Math.Sqrt(3 * Math.Pow(input, 2));
            return result;
        }

        private static decimal CalculatingFaceDiagaonal(double input)
        {
            var result = (decimal)Math.Sqrt(2 * Math.Pow(input, 2));
            return result;
        }
    }
}
