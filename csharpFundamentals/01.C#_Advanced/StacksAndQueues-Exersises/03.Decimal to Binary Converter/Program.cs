namespace _03.Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();

            while (input >= 1)
            {
                if (input % 2 == 0)
                {
                    stack.Push("0");
                }
                else
                {
                    stack.Push("1");
                }
                input /= 2;
            }

            var binaryNumber = string.Empty;
            while (stack.Count != 0)
            {
                binaryNumber += stack.Pop();
            }

            if (binaryNumber == string.Empty)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(binaryNumber);
            }
        }
    }
}
