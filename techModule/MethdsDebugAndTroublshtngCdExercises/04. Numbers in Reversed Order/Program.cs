using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            ReverseTheNumber(input);
        }

        private static void ReverseTheNumber(string input)
        {
            var result = "";
            int inputLenght = input.Length;
            while (inputLenght >= 1)
            {
                result += input[inputLenght - 1];
                inputLenght--;
            }
            Console.WriteLine(result);
        }
    }
}
