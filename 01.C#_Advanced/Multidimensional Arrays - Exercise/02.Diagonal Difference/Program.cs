namespace _02.Diagonal_Difference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            long primaryDiagonalSum = 0;
            long secondaryDiagonalSum = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var values = Console.ReadLine()
                    .Split()
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = values[columns];

                    if (rows == columns)
                    {
                        primaryDiagonalSum += values[columns];
                    }
                    if (rows + columns == matrix.GetLength(1) - 1)
                    {
                        secondaryDiagonalSum += values[columns];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
