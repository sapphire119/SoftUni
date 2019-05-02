using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());
            var max  = GetDiffrence(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(max);
        }

        static int GetDiffrence(int firstNumber, int secondNumber, int thirdNumber)
        {
            var result = Math.Max(firstNumber, Math.Max(secondNumber, thirdNumber));
            return result;
        }
    }
}
