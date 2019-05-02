namespace _02._Crypto_Master
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {

            var numbersInput = Console.ReadLine()
                    .Split(", ".ToCharArray())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(long.Parse)
                    .ToArray();

            var numbersQue = new Queue<long>();

            foreach (var number in numbersInput)
            {
                numbersQue.Enqueue(number);
            }

            var enqQueue = new Queue<long>();
            for (int count = 0; count < numbersQue.Count; count++)
            {
                var currentNumber = numbersQue.Dequeue();
                var minDiffrence = decimal.MaxValue;
                var step = -1;
                for (int queCount = 1; queCount <= numbersQue.Count; queCount++)
                {
                    var nextNumber = numbersQue.Dequeue();

                    if (currentNumber < nextNumber)
                    {
                        decimal currentDiffrence = nextNumber - currentNumber;

                        if (minDiffrence > currentDiffrence)
                        {
                            minDiffrence = currentDiffrence;
                            step = queCount;
                        }
                    }
                    numbersQue.Enqueue(nextNumber);
                }

                var counter = 1;
                var oldNumber = currentNumber;

                var copyOfnumbersQue = new Queue<long>(numbersQue);
                copyOfnumbersQue.Enqueue(currentNumber);

                var tempQue = new Queue<long>();
                tempQue.Enqueue(oldNumber);

                if (step != -1)
                {
                    while (true)
                    {
                        var number = copyOfnumbersQue.Dequeue();
                        copyOfnumbersQue.Enqueue(number);
                        if (counter == step)
                        {
                            if (number == oldNumber)
                            {
                                break;
                            }

                            counter = 0;

                            if (oldNumber < number)
                            {
                                oldNumber = number;
                                tempQue.Enqueue(oldNumber);
                            }
                            else
                            {
                                break;
                            }
                        }
                        counter++;
                    }
                }

                numbersQue.Enqueue(currentNumber);

                if (tempQue.Count > enqQueue.Count)
                {
                    enqQueue = new Queue<long>(tempQue);
                }
            }
            //Console.WriteLine(string.Join(", ", enqQueue));
            Console.WriteLine(enqQueue.Count);
        }
    }
}
