namespace _01._Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //int[,] intMatrix = new int[3, 4]; //Масив 3 * 4 = 12 клетки

            //int[,,] matrix =
            //{
            //    {
            //        {1, 2},
            //        {3, 4}

            //    },
            //    {
            //        {2, 4},
            //        {5, 6}
            //    }
            //};

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int column = 0; column < matrix.GetLength(1); column++)
            //    {
            //        for (int height = 0; height < matrix.GetLength(2); height++)
            //        {
            //            Console.Write("{0} ", matrix[row, column, height]);
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}

            //int x = matrix[1, 0, 1];
            //Console.WriteLine(x);
            ////
            //int[,] matrix2 =
            //{
            //    { 5, 2, 3, 1 },
            //    { 1, 9, 2, 4 },
            //    { 9, 8, 6, 11 }
            //};

            //for (int row = 0; row < matrix2.GetLength(0); row++)
            //{
            //    for (int column = 0; column < matrix2.GetLength(1); column++)
            //    {
            //        Console.Write("{0} ", matrix2[row, column]);
            //    }
            //    Console.WriteLine();
            //}
            FirstTask();
        }

        private static void FirstTask()
        {
            var rowsAndColumns = Console.ReadLine().Split(',',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rowsCount = rowsAndColumns[0];
            var columnsCount = rowsAndColumns[1];

            var matrix = new int[rowsCount, columnsCount];
            for (int rows = 0; rows < rowsCount; rows++)
            {
                var values = Console.ReadLine()
                    .Split(',',StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int columns = 0; columns < columnsCount; columns++)
                {
                    matrix[rows, columns] = values[columns];
                }
            }

            int totalSumOfAllElements = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    totalSumOfAllElements += matrix[rows, columns];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(totalSumOfAllElements);

        }
    }
}
