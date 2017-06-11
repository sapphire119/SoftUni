using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            PrintCompleteFigure(number);
        }

        private static void PrintCompleteFigure(int number)
        {
            PrintHeader(number);
            PrintBody(number);
            PrintFooter(number);
        }

        private static void PrintHeader(int number)
        {
            Console.WriteLine(new string('-',number*2));
        }

        private static void PrintBody(int number)
        {
            for (int i = 1; i <= number-2; i++)
            {
                PrintBodyOfFigure(number);
            }
        }

        private static void PrintBodyOfFigure(int number)
        {
            Console.Write("-");
            for (int i = 1; i <= number-1; i++) 
            {
                Console.Write("\\/");
            }
            Console.WriteLine("-");
        }

        private static void PrintFooter(int number)
        {
            Console.WriteLine(new string('-', number * 2));
        }
    }
}
