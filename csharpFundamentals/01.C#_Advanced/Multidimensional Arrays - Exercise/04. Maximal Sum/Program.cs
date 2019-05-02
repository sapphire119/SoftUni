namespace _04._Maximal_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rowsCount = rowsAndColumns[0];
            var columnsCount = rowsAndColumns[1];

            long[,] matrix = new long[rowsCount, columnsCount];

            for (int rows = 0; rows < rowsCount; rows++)
            {
                var values = Console.ReadLine().Split().Where(s => !string.IsNullOrWhiteSpace(s)).Select(long.Parse).ToArray();

                for (int columns = 0; columns < columnsCount; columns++)
                {
                    matrix[rows, columns] = values[columns];
                }
            }

            long maxSum = long.MinValue;
            var rowIndexStart = 0;
            var columnsStartIndex = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 2; columns++)
                {
                    long tempSum = matrix[rows,columns] + matrix[rows, columns + 1] + matrix[rows, columns + 2]
                        + matrix[rows + 1, columns] + matrix[rows + 1, columns + 1] + matrix[rows + 1, columns + 2]
                        + matrix[rows + 2, columns] + matrix[rows + 2, columns + 1] + matrix[rows + 2, columns + 2];

                    if (maxSum < tempSum)
                    {
                        maxSum = tempSum;
                        rowIndexStart = rows;
                        columnsStartIndex = columns;
                    }
                }
            }

            Console.WriteLine("Sum = {0}",maxSum);
            for (int rows = rowIndexStart; rows <= rowIndexStart + 2; rows++)
            {
                for (int columns = columnsStartIndex; columns <= columnsStartIndex + 2; columns++)
                {
                    Console.Write("{0} ", matrix[rows, columns]);
                }
                Console.WriteLine();
            }
        }
    }
}
