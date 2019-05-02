namespace _05._Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var firstNumber = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(firstNumber);

            var calculatedSums = new List<long>();
            var currentNumberUsed = firstNumber;
            var count = 0;

            var firstEquation = currentNumberUsed + 1;
            var secondEquation = 2 * currentNumberUsed + 1;
            var thirdEquation = currentNumberUsed + 2;

            while (queue.Count <= 50)
            {
                calculatedSums.Add(firstEquation);
                calculatedSums.Add(secondEquation);
                calculatedSums.Add(thirdEquation);
                
                queue.Enqueue(firstEquation);
                if (queue.Count >= 50)
                {
                    break;
                }
                queue.Enqueue(secondEquation);
                if (queue.Count >= 50)
                {
                    break;
                }
                queue.Enqueue(thirdEquation);

                currentNumberUsed = calculatedSums[count];
                count++;

                firstEquation = currentNumberUsed + 1;
                secondEquation = 2 * currentNumberUsed + 1;
                thirdEquation = currentNumberUsed + 2;
            }

            Console.WriteLine(string.Join(" ",queue));
        }
    }
}
