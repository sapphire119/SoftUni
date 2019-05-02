using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            if (type == "string")
            {
                var firstString = Console.ReadLine();
                var secondString = Console.ReadLine();
                var getMaximum = GetMax(firstString, secondString);
                Console.WriteLine(getMaximum);
            }
            else if (type =="int")
            {
                var firstNumber = int.Parse(Console.ReadLine());
                var secondNumber = int.Parse(Console.ReadLine());
                var getMaximum = GetMax(firstNumber, secondNumber);
                Console.WriteLine(getMaximum);
            }
            else if (type =="char")
            {
                var firstChar = char.Parse(Console.ReadLine());
                var secondChar = char.Parse(Console.ReadLine());
                var getMaximum = GetMax(firstChar, secondChar);
                Console.WriteLine(getMaximum);
            }
        }

        static int GetMax(int firstNumber, int secondNumber)
        {
            var result = Math.Max(firstNumber, secondNumber);
            return result;
        }

        static string GetMax(string firstString, string secondString)
        {
            var result = "";
            if (firstString.CompareTo(secondString) >= 0)
            {

                result = firstString;
            }
            else
            {
                result = secondString;
            }
            return result;
        }

        static char GetMax(char firstChar, char secondChar)
        {
            var result = (char)Math.Max(firstChar, secondChar);
            return result;
        }
    }
}
