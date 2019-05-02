namespace _02._Square_With_Maximum_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndColumnsCount = Console.ReadLine()
                .Split(',')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(int.Parse)
                .ToArray();

            var rowsCount = rowsAndColumnsCount[0];
            var columnsCount = rowsAndColumnsCount[1];

            int[,] matrix = new int[rowsCount, columnsCount];

            for (int rows = 0; rows < rowsCount; rows++)
            {
                var values = Console.ReadLine()
                .Split(',')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(int.Parse)
                .ToArray();

                for (int columns = 0; columns < columnsCount; columns++)
                {
                    matrix[rows, columns] = values[columns];
                }
            }

            var sum = 0;
            var maxSum = int.MinValue;
            var currentRowStartIndex = 0;
            var currentColumnStartIndex = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
                {

                    var firstElement = matrix[rows, columns];
                    var secondElement = matrix[rows, columns + 1];
                    var thirdElement = matrix[rows + 1, columns];
                    var fourthElement = matrix[rows + 1, columns + 1];

                    sum = firstElement + thirdElement + secondElement + fourthElement;
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        currentRowStartIndex = rows;
                        currentColumnStartIndex = columns;
                    }
                    sum = 0;
                }
            }

            for (int rows = currentRowStartIndex; rows <= currentRowStartIndex + 1; rows++)
            {
                for (int columns = currentColumnStartIndex; columns <= currentColumnStartIndex + 1; columns++)
                {
                    Console.Write("{0} ",matrix[rows, columns]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
