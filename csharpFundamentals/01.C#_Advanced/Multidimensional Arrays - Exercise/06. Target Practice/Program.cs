namespace _06._Target_Practice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var rowsAndColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var snakeString = Console.ReadLine();
            var shotParams = Console.ReadLine().Split().Select(long.Parse).ToArray();

            var rowsCount = rowsAndColumns[0];
            var columnsCount = rowsAndColumns[1];

            string[,] matrix = new string[rowsCount, columnsCount];

            var queSnake = new Queue<char>();
            foreach (var item in snakeString)
            {
                queSnake.Enqueue(item);
            }

            long index = 1;
            for (int rows = rowsCount - 1; rows >= 0; rows--)
            {
                if (index % 2 == 1)
                {
                    for (int columns = columnsCount - 1; columns >= 0; columns--)
                    {
                        var currentLetter = queSnake.Dequeue();
                        matrix[rows, columns] = currentLetter.ToString();
                        queSnake.Enqueue(currentLetter);
                    }
                }
                else if (index % 2 == 0)
                {
                    for (int columns = 0; columns < columnsCount; columns++)
                    {
                        var currentLetter = queSnake.Dequeue();
                        matrix[rows, columns] = currentLetter.ToString();
                        queSnake.Enqueue(currentLetter);
                    }
                }
                index++;
            }

            long rowIndexOfShot = shotParams[0];
            long columnIndexOfShot = shotParams[1];
            long shotRadius = shotParams[2];

            if ((0 <= rowIndexOfShot && rowIndexOfShot <= matrix.GetLength(0) - 1) &&
                ((0 <= columnIndexOfShot && columnIndexOfShot <= matrix.GetLength(1) - 1)))
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        long rowValue = (long)Math.Pow(row - rowIndexOfShot,2);
                        long columnValue = (long)Math.Pow(col - columnIndexOfShot,2);
                        long shotValueRadius = (long)Math.Pow(shotRadius, 2);
                        if (rowValue + columnValue <= shotValueRadius) 
                        {
                            matrix[row, col] = string.Empty;
                        }
                    }
                }

                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    for (int rows = 0; rows < matrix.GetLength(0); rows++)
                    {
                        if (matrix[rows, columns] == string.Empty)
                        {
                            RotateElements(matrix, rows, columns);
                            break;
                        }
                    }
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    var currentElement = matrix[rows, columns];
                    if (currentElement != string.Empty)
                    {
                        Console.Write("{0}", currentElement);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void RotateElements(string[,] matrix, int rowIndextAtWhichThereIsAletter, int columnIndexAtWhichThereIsAltter)
        {
            var stack = new Stack<string>();

            for (int rows = 0; rows < rowIndextAtWhichThereIsAletter; rows++)
            {
                stack.Push(matrix[rows, columnIndexAtWhichThereIsAltter]);
            }

            if (!stack.Any())
            {
                return;
            }


            var rowIndexForRotation = 0;
            for (int rows = matrix.GetLength(0) - 1; rows >= 0; rows--)
            {
                if (matrix[rows, columnIndexAtWhichThereIsAltter] == string.Empty)
                {
                    rowIndexForRotation = rows;
                    break;
                }
            }

            for (int rows = rowIndexForRotation; rows >= 0; rows--)
            {
                var currentElement = string.Empty;
                if (stack.Any())
                {
                    currentElement = stack.Pop();
                }
                matrix[rows, columnIndexAtWhichThereIsAltter] = currentElement;
            }
        }
    }
}
