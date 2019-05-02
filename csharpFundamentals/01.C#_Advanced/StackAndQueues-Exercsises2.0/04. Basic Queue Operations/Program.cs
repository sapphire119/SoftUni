using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var countOfElementsToAdd = input[0];
            var numberOfElementsToRemove = input[1];
            var elementToLookForInTheQueue = input[2];

            var queue = new Queue<int>();

            for (int i = 0; i < countOfElementsToAdd; i++)
            {
                queue.Enqueue(numbersInput[i]);
            }

            for (int j = 0; j < numberOfElementsToRemove; j++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementToLookForInTheQueue))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (!queue.Contains(elementToLookForInTheQueue))
            {
                Console.WriteLine(queue.Min());
            }


        }
    }
}
