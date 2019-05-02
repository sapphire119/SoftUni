namespace _01._Reverse_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<string>();

            var numbers = input.Split().ToArray();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            Console.WriteLine(string.Join(" ",stack));
        }
    }
}
