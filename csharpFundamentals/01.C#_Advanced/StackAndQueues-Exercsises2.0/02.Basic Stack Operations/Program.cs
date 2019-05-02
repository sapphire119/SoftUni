namespace _02.Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var elementsToPushInStack = input[0];
            var elementsToPopFromStack = input[1];
            var elementToLookForInStack = input[2];

            var numbers = new Stack<int>();

            for (int i = 0; i < elementsToPushInStack; i++)
            {
                numbers.Push(numbersInput[i]);
            }

            for (int i = 0; i < elementsToPopFromStack; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(elementToLookForInStack))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count != 0)
            {
                Console.WriteLine(numbers.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
