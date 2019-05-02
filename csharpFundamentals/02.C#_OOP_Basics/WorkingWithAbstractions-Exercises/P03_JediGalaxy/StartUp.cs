using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        static void Main()
        {
            var rowsAndColumns = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            
            int[,] matrix = FillMatrix(rowsAndColumns);

            var sum = 0M;

            string ivoRowAndColumnInput;
            string evilRowAndColumnInput;
            while (((ivoRowAndColumnInput = Console.ReadLine()) != "Let the Force be with you") &&
                    ((evilRowAndColumnInput = Console.ReadLine()) != "Let the Force be with you"))
            {
                EvilPowerDestroysCells(evilRowAndColumnInput, matrix);
                sum = IvoCollectsStars(ivoRowAndColumnInput, matrix, sum);
            }

            Console.WriteLine(sum);
        }

        private static int[,] FillMatrix(int[] rowsAndColumns)
        {
            int rowsCount = rowsAndColumns[0];
            int columnsCount = rowsAndColumns[1];

            int[,] matrix = new int[rowsCount, columnsCount];

            for (int row = 0, value = 0; row < rowsCount; row++)
            {
                for (int column = 0; column < columnsCount; column++)
                {
                    matrix[row, column] = value++;
                }
            }

            return matrix;
        }

        private static decimal IvoCollectsStars(string ivoRowAndColumnInput, int[,] matrix, decimal sum)
        {
            int[] ivoRowAndColumn = ivoRowAndColumnInput
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int ivoRow = ivoRowAndColumn[0];
            int ivoColumn = ivoRowAndColumn[1];

            for (int row = ivoRow, column = ivoColumn; row >= 0 && column < matrix.GetLength(1); row--, column++) 
            {
                if (row < matrix.GetLength(0) && column >= 0)
                {
                    sum += matrix[row, column];
                }
            }

            //while (ivoRow >= 0 && ivoColumn < matrix.GetLength(1))
            //{
            //    if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoColumn >= 0 && ivoColumn < matrix.GetLength(1))
            //    {
            //        sum += matrix[ivoRow, ivoColumn];
            //    }

            //    ivoColumn++;
            //    ivoRow--;
            //}

            return sum;
        }

        private static void EvilPowerDestroysCells(string evilRowAndColumnInput, int[,] matrix)
        {
            var evilRowAndColumn = evilRowAndColumnInput
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var evilRow = evilRowAndColumn[0];
            var evilColumn = evilRowAndColumn[1];

            for (int row = evilRow, column = evilColumn; row >= 0 && column >= 0; row--, column--)
            {
                if (row < matrix.GetLength(0) && column < matrix.GetLength(1))
                {
                    matrix[row, column] = 0; 
                }
            }
        }
    }
}
