namespace _01.Reverse_Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++) 
            {
                stack.Push(input[i]);
            }

            var result = string.Empty;

            while (stack.Count != 0)
            {
                result += stack.Pop();
            }

            Console.WriteLine(result);
        }
    }
}
