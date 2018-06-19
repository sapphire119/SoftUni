namespace _02._Knight_Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndColumns = int.Parse(Console.ReadLine());

            var rowsCount = rowsAndColumns;
            var columnsCount = rowsAndColumns;

            var matrix = new char[rowsCount, columnsCount];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var input = Console.ReadLine();
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    matrix[rows, columns] = input[columns];
                }
            }

            var maxThreat = int.MinValue;
            var knightRow = 0;
            var knightColumn = 0;
            var removedKnights = 0;

            while (true)
            {
                var currentThreat = 0;
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int columns = 0; columns < matrix.GetLength(1); columns++)
                    {
                        if (matrix[rows, columns] == 'K')
                        {
                            currentThreat = CalculateThreat(rows, columns, matrix);
                            if (maxThreat < currentThreat)
                            {
                                maxThreat = currentThreat;
                                knightRow = rows;
                                knightColumn = columns;
                            }
                        }
                    }
                }

                if (maxThreat == 0)
                {
                    break;
                }
                matrix[knightRow, knightColumn] = '0';

                maxThreat = int.MinValue;
                knightRow = 0;
                knightColumn = 0;

                removedKnights++;
            }
            Console.WriteLine(removedKnights);
        }

        private static int CalculateThreat(int rowsCount, int columnsCount, char[,] matrix)
        {
            var threatCount = 0;
            threatCount = CheckLeft(threatCount, columnsCount, rowsCount, matrix);
            threatCount = CheckRight(threatCount, columnsCount, rowsCount, matrix);
            return threatCount;
        }

        private static int CheckRight(int threatCount, int columnsCount, int rowsCount, char[,] matrix)
        {
            threatCount = CheckTopRight(threatCount, columnsCount, rowsCount, matrix);
            threatCount = CheckBottomRight(threatCount, columnsCount, rowsCount, matrix);

            return threatCount;
        }

        private static int CheckBottomRight(int threatCount, int columnsCount, int rowsCount, char[,] matrix)
        {
            var matrixRowsCount = matrix.GetLength(0) - 1;
            var matrixColumnCount = matrix.GetLength(1) - 1;

            if (rowsCount + 1 <= matrixRowsCount && columnsCount + 2 <= matrixColumnCount)
            {
                if (matrix[rowsCount + 1, columnsCount + 2] == 'K')
                {
                    threatCount++;
                }
            }
            if (rowsCount + 2 <= matrixRowsCount && columnsCount + 1 <= matrixColumnCount)
            {
                if (matrix[rowsCount + 2, columnsCount +1] == 'K')
                {
                    threatCount++;
                }
            }
            
            return threatCount;
        }

        private static int CheckTopRight(int threatCount, int columnsCount, int rowsCount, char[,] matrix)
        {
            var matrixColumnCount = matrix.GetLength(1) - 1;

            if (rowsCount - 1 >= 0 && columnsCount + 2 <= matrixColumnCount)
            {
                if (matrix[rowsCount - 1, columnsCount + 2] == 'K')
                {
                    threatCount++;
                }
            }
            if (rowsCount - 2 >= 0 && columnsCount + 1 <= matrixColumnCount)
            {
                if (matrix[rowsCount - 2, columnsCount + 1] == 'K')
                {
                    threatCount++;
                }
            }

            return threatCount;
        }

        private static int CheckLeft(int threatCount, int columnsCount, int rowsCount, char[,] matrix)
        {
            threatCount = CheckTopLeft(threatCount, rowsCount, columnsCount, matrix);
            threatCount = CheckBottomLeft(threatCount, rowsCount, columnsCount, matrix);

            return threatCount;
        }

        private static int CheckTopLeft(int threatCount, int rowsCount, int columnsCount, char[,] matrix)
        {
            if (rowsCount - 2 >= 0 && columnsCount - 1 >= 0)
            {
                if (matrix[rowsCount - 2, columnsCount - 1] == 'K')
                {
                    threatCount++;
                }
            }
            if (rowsCount - 1 >= 0 && columnsCount - 2 >= 0)
            {
                if (matrix[rowsCount - 1, columnsCount - 2] == 'K') 
                {
                    threatCount++;
                }
            }

            return threatCount;
        }

        private static int CheckBottomLeft(int threatCount, int rowsCount, int columnsCount, char[,] matrix)
        {
            int matrixRowCount = matrix.GetLength(0) - 1;

            if (rowsCount + 2 <= matrixRowCount && columnsCount - 1 >= 0)
            {
                if (matrix[rowsCount + 2, columnsCount - 1] == 'K')
                {
                    threatCount++;
                }
            }
            if (rowsCount + 1 <= matrixRowCount && columnsCount - 2 >= 0)
            {
                if (matrix[rowsCount + 1, columnsCount - 2] == 'K')
                {
                    threatCount++;
                }
            }

            return threatCount;
        }
    }
}