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
            PrintMasterNumber(input);
        }

        private static void PrintMasterNumber(int input)
        {
            for (int i = 1; i <= input; i++)
            {
                
                if (SumOfDigits(i) &&
                    ContainsEvenDigit(i) &&
                    IsPalindrome(i.ToString()))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsPalindrome(string input)
        {
            var result = string.Empty;
            byte inputLenght = (byte)input.Length;
            while (inputLenght >= 1)
            {
                result += input[inputLenght - 1];
                inputLenght--;
            }
            if (result == input)
            {
                return true;
            }
            return false;   
        }

        static bool ContainsEvenDigit(int number)
        {
            byte result = 0;
            while (number > 0)
            {
                result = (byte)(number % 10);
                if (result % 2 == 0)
                {
                    return true;
                }
                number /= 10;
                result = 0;
            }
            return false;
        }

        private static bool SumOfDigits(int number)
        {
            byte result = 0;
            while (number > 0)
            {
                result += (byte)(number % 10);
                number /= 10;
            }
            if (result % 7 == 0)
            {
                return true;
            }
            return false;
        }


    }
}
