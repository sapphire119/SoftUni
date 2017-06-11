using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            PrintTriagnle(number);
        }

        private static void PrintTriagnle(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintPartOfTriangle(i);
            }
            for (int i = number-1; i >=1; i--)
            {
                PrintPartOfTriangle(i);
            }
        }

        private static void PrintPartOfTriangle(int numb)
        {
            for (int i = 1; i <= numb; i++)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }

       

       
    }
}
