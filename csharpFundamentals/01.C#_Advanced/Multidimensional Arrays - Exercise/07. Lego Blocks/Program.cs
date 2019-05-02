namespace _07._Lego_Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            List<List<long>> firstList = new List<List<long>>();
            List<List<long>> secondList = new List<List<long>>();
            for (int i = 0; i < n; i++)
            {
                firstList.Add(new List<long>());
                secondList.Add(new List<long>());
            }

            for (int i = 0; i < n; i++)
            {
                var firstArrayElements = Console.ReadLine()
                    .Split()
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(long.Parse)
                    .ToArray();

                firstList[i].AddRange(firstArrayElements);
            }

            for (int j = 0; j < n; j++)
            {
                var secondArrayElements = Console.ReadLine()
                    .Split()
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(long.Parse)
                    .ToArray();

                secondList[j].AddRange(secondArrayElements);
                secondList[j].Reverse();
            }

            var firstRowCount = firstList[0].Count + secondList[0].Count;
            for (int rows = 0; rows < firstList.Count; rows++)
            {
                var tempRowCount = firstList[rows].Count + secondList[rows].Count;
                if (tempRowCount != firstRowCount)
                {
                    var rowCount = firstList.Sum(l => l.Count) + secondList.Sum(l => l.Count);
                    Console.WriteLine($"The total number of cells is: {rowCount}");
                    return;
                }
            }

            for (int i = 0; i < n; i++)
            {
                firstList[i].AddRange(secondList[i]);
                Console.WriteLine("["+ string.Join(", ",firstList[i]) +"]");
            }
        }
    }
}
