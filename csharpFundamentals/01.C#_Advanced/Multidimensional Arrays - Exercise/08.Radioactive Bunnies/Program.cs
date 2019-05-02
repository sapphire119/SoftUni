namespace _08.Radioactive_Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {

            var rowsAndColumns = Console.ReadLine().Split().Where(s => !string.IsNullOrWhiteSpace(s)).Select(long.Parse).ToArray();

            var rowsCount = rowsAndColumns[0];
            var columnsCount = rowsAndColumns[1];

            char[,] matrix = new char[rowsCount, columnsCount];
            char[,] matrixCopy = new char[matrix.GetLength(0), matrix.GetLength(1)];


            var playerCount = 0;
            var playerRow = 0;
            var playerColumn = 0;
            for (int rows = 0; rows < rowsCount; rows++)
            {
                var elements = Console.ReadLine();
                for (int columns = 0; columns < columnsCount; columns++)
                {
                    var currentElement = elements[columns];
                    if (currentElement == 'P' || currentElement == 'B' || currentElement == '.')
                    {
                        matrix[rows, columns] = currentElement;
                        matrixCopy[rows, columns] = currentElement;
                        if (currentElement == 'P')
                        {
                            playerCount++;
                            playerRow = rows;
                            playerColumn = columns;
                        }
                    }
                }
                if (playerCount > 1)
                {
                    return;
                }
            }

            var playerMovesInput = Console.ReadLine();
            var playerMovesQue = new Queue<char>();

            foreach (var movement in playerMovesInput)
            {
                playerMovesQue.Enqueue(movement);
            }

            var isGameOver = false;
            var endMessage = string.Empty;
            while (isGameOver != true)
            {
                if (playerMovesQue.Any())
                {
                    var futureMove = playerMovesQue.Dequeue();
                    if (futureMove == 'L')
                    {
                        var nextMoveLeft = playerColumn - 1;
                        if (nextMoveLeft < 0)
                        {
                            endMessage = $"won: {playerRow} {playerColumn}";
                            matrixCopy[playerRow, playerColumn] = '.';
                            isGameOver = true;
                        }
                        else
                        {
                            matrixCopy[playerRow, playerColumn] = '.';
                            matrixCopy[playerRow, nextMoveLeft] = 'P';
                            playerColumn = nextMoveLeft;
                        }
                    }
                    else if (futureMove == 'R')
                    {
                        var nextMoveRight = playerColumn + 1;
                        if (nextMoveRight >= matrix.GetLength(1))
                        {
                            endMessage = $"won: {playerRow} {playerColumn}";
                            matrixCopy[playerRow, playerColumn] = '.';
                            isGameOver = true;
                        }
                        else
                        {
                            matrixCopy[playerRow, playerColumn] = '.';
                            matrixCopy[playerRow, nextMoveRight] = 'P';
                            playerColumn = nextMoveRight;
                        }
                    }
                    else if (futureMove == 'U')
                    {
                        var nextMoveUp = playerRow - 1;
                        if (nextMoveUp < 0)
                        {
                            endMessage = $"won: {playerRow} {playerColumn}";
                            matrixCopy[playerRow, playerColumn] = '.';
                            isGameOver = true;
                        }
                        else
                        {
                            matrixCopy[playerRow, playerColumn] = '.';
                            matrixCopy[nextMoveUp, playerColumn] = 'P';
                            playerRow = nextMoveUp;
                        }
                    }
                    else if (futureMove == 'D')
                    {
                        var nextMoveDown = playerRow + 1;
                        if (nextMoveDown >= matrixCopy.GetLength(0))
                        {
                            endMessage = $"won: {playerRow} {playerColumn}";
                            matrixCopy[playerRow, playerColumn] = '.';
                            isGameOver = true;
                        }
                        else
                        {
                            matrixCopy[playerRow, playerColumn] = '.';
                            matrixCopy[nextMoveDown, playerColumn] = 'P';
                            playerRow = nextMoveDown;
                        }
                    }

                }
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int columns = 0; columns < matrix.GetLength(1); columns++)
                    {
                        if (matrix[rows, columns] == 'B')
                        {
                            SpreadBunnies(rows, columns, matrixCopy);
                        }
                    }
                }
                for (int rows = 0; rows < matrixCopy.GetLength(0); rows++)
                {
                    for (int columns = 0; columns < matrix.GetLength(1); columns++)
                    {
                        matrix[rows, columns] = matrixCopy[rows, columns];
                    }
                }

                if (matrix[playerRow, playerColumn] == 'B' && isGameOver != true)
                {
                    isGameOver = true;
                    endMessage = $"dead: {playerRow} {playerColumn}";
                }
            }
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    Console.Write("{0}", matrix[rows, columns]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(endMessage);
        }

        private static void SpreadBunnies(int rowIndexOfBunny, int columnIndexOfBunny, char[,] matrixCopy)
        {
            for (int rows = 0; rows < matrixCopy.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrixCopy.GetLength(1); columns++)
                {
                    if (Math.Pow(rows - rowIndexOfBunny, 2) + Math.Pow(columns - columnIndexOfBunny, 2) <= 1)
                    {
                        matrixCopy[rows, columns] = 'B';
                    }
                }
            }
        }
    }
}
