namespace _03._Squares_in_Matrix
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

            string[,] matrix = new string[rowsCount, columnsCount];

            for (int rows = 0; rows < rowsCount; rows++)
            {
                var values = Console.ReadLine().Split().ToArray();

                for (int columns = 0; columns < columnsCount; columns++)
                {
                    matrix[rows, columns] = values[columns];
                }
            }

            var countOfEqual2x2Cells = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
                {
                    var firstLetter = matrix[rows, columns];
                    var secondLetter = matrix[rows, columns + 1];
                    var thirdLetter = matrix[rows + 1, columns];
                    var fourthLetter = matrix[rows + 1, columns + 1];

                    if (firstLetter == secondLetter && secondLetter == thirdLetter && thirdLetter == fourthLetter)
                    {
                        countOfEqual2x2Cells++;
                    }
                }
            }

            Console.WriteLine(countOfEqual2x2Cells);
        }
    }
}
