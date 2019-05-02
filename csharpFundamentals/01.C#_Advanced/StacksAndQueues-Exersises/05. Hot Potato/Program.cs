namespace _05._Hot_Potato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var countOfTimesThePotatoIsPassed = int.Parse(Console.ReadLine());

            var kidsToQue = input.Split();

            var kids = new Queue<string>();

            foreach (var kid in kidsToQue)
            {
                kids.Enqueue(kid);
            }

            var kidsArr = kids.ToArray();
            var kidsList = kidsArr.ToList();

            var index = kidsArr.Length - 1;
            var currentCount = 0;
            //var currentTimesThePotatoIsPassed = 0;
            while (kidsList.Count != 1)
            {
                if (index >= kidsList.Count)
                {
                    index = 0;
                }
                if (currentCount == countOfTimesThePotatoIsPassed)
                {
                    Console.WriteLine($"Removed {kidsList[index]}");
                    kidsList.RemoveAt(index);
                    currentCount = 1;
                    continue;
                }
                index++;
                currentCount++;
            }

            Console.WriteLine($"Last is {string.Join("",kidsList)}");
        }
    }
}
