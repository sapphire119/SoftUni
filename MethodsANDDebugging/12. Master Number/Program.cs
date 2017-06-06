using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            PrintMasterNumbers(input);
            
        }

        private static void PrintMasterNumbers(int input)
        {
            var result = string.Empty;
            var testString = string.Empty;
            for (int i = 1; i <= input; i++)
            {
                testString = Convert.ToString(i);
                var inputLenght = i.ToString().Length;
                while (inputLenght >= 1)
                {
                    result += testString[testString.Length - 1];
                    inputLenght--;
                }
                if (result == i.ToString())
                {
                    Console.WriteLine(result);
                }
                result = string.Empty;
            }
        }
    }
}
