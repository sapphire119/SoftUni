namespace _03.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxElements = new Stack<int>();

            var maxElement = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                var command = input[0];

                if (command == "1")
                {
                    var numberToPushInStack = int.Parse(input[1]);
                    if (maxElement < numberToPushInStack)
                    {
                        maxElement = numberToPushInStack;
                        maxElements.Push(maxElement);
                    }
                    stack.Push(numberToPushInStack);
                }
                else if (command == "2")
                {
                    if (maxElement == stack.Peek() && stack.Count != 0)
                    {
                        maxElements.Pop();
                        maxElement = maxElements.Peek();
                    }
                    else if(stack.Count == 0)
                    {
                        maxElement = int.MinValue;
                    }
                    stack.Pop();
                }
                else if (command == "3")
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(maxElement);
                    }
                }
            }

        }
    }
}