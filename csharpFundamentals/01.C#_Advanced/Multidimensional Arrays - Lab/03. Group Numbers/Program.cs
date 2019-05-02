namespace _03._Group_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //int rowsCounter = int.Parse(Console.ReadLine());

            //int[][] jaggedArray/*назъбен масив*/ = new int[rowsCounter][];

            //for (int rows = 0; rows < rowsCounter; rows++)
            //{
            //    jaggedArray[rows] = Console.ReadLine().Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();
            //}

            //for (int rows = 0; rows < jaggedArray.Length; rows++)
            //{
            //    for (int columns = 0; columns < jaggedArray[rows].Length; columns++)
            //    {
            //        Console.Write("{0} ",jaggedArray[rows][columns]);
            //    }
            //    Console.WriteLine();
            //}

            //Първи вараинт
            //var values = Console.ReadLine().Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();

            //List<int>[] jaggedArray = new List<int>[3];

            //for (int rows = 0; rows < jaggedArray.Length; rows++)
            //{
            //    jaggedArray[rows] = new List<int>();
            //}

            //foreach (var value in values)
            //{
            //    var absoluteValue = Math.Abs(value);
            //    if (absoluteValue % 3 == 0)
            //    {
            //        jaggedArray[0].Add(value);
            //    }
            //    else if (absoluteValue % 3 == 1)
            //    {
            //        jaggedArray[1].Add(value);
            //    }
            //    else if (absoluteValue % 3 == 2)
            //    {
            //        jaggedArray[2].Add(value);
            //    }
            //}

            //for (int rows = 0; rows < jaggedArray.Length; rows++)
            //{
            //    for (int columns = 0; columns < jaggedArray[rows].Count; columns++)
            //    {
            //        Console.Write("{0} ",jaggedArray[rows][columns]);
            //    }
            //    Console.WriteLine();
            //}


            var secondValues = Console.ReadLine().Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();

            var sizesOfArrays = new int[3];

            foreach (var number in secondValues)
            {
                int abs = Math.Abs(number % 3);
                sizesOfArrays[abs]++;
            }

            int[][] jaggedArraySecond = new int[3][];

            for (int counter = 0; counter < sizesOfArrays.Length; counter++)
            {
                jaggedArraySecond[counter] = new int[sizesOfArrays[counter]];
            }

            var index = new int[3];
            foreach (var value in secondValues)
            {
                var remainder = Math.Abs(value % 3);
                jaggedArraySecond[remainder][index[remainder]] = value;
                index[remainder]++;
            }
        }
    }
}
