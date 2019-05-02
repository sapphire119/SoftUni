namespace _05._Rubiks_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfCommands = int.Parse(Console.ReadLine());

            var rowsCount = rowsAndColumns[0];
            var columnsCount = rowsAndColumns[1];


            int[,] matrix = new int[rowsCount, columnsCount];
            //fill each row with increasing integers, starting from one
            var index = 1;
            for (int rows = 0; rows < rowsCount; rows++)
            {
                for (int columns = 0; columns < columnsCount; columns++)
                {
                    matrix[rows, columns] = index++;
                }
            }

            for (int commandCount = 0; commandCount < numberOfCommands; commandCount++)
            {
                var inputCommand = Console.ReadLine().Split().ToArray();
                if (inputCommand.Length == 3)
                {
                    var command = inputCommand[1];
                    switch (command)
                    {
                        case "up": MoveUpOrDown(inputCommand, matrix); break;
                        case "down": MoveUpOrDown(inputCommand, matrix); break;
                        case "left": MoveLeftOrRight(inputCommand, matrix); break;
                        case "right": MoveLeftOrRight(inputCommand, matrix); break;
                        default:
                            break;
                    }
                }
            }
            var number = 1;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    if (matrix[rows, columns] != number)
                    {
                        var rowIndexAndColumnIndex = FindRowIndexAndColumnIndex(number, matrix)
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

                        var rowIndex = rowIndexAndColumnIndex[0];
                        var columnIndex = rowIndexAndColumnIndex[1];

                        var oldValue = matrix[rows, columns];
                        matrix[rows, columns] = matrix[rowIndex, columnIndex];
                        matrix[rowIndex, columnIndex] = oldValue;
                        Console.WriteLine($"Swap ({rows}, {columns}) with ({rowIndex}, {columnIndex})");
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    number++;
                }
            }
        }

        private static string FindRowIndexAndColumnIndex(int number, int[,] matrix)
        {
            var rowAndColumn = string.Empty;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    if (matrix[rows, columns] == number)
                    {
                        return rowAndColumn += rows + " " + columns;
                    }
                }
            }
            return null;
        }

        private static void MoveLeftOrRight(string[] inputCommand, int[,] matrix)
        {
            var row = int.Parse(inputCommand[0]);
            if (!(0 <= row && row <= matrix.GetLength(0)))
            {
                return;
            }
            var command = inputCommand[1];
            var timesToMove = int.Parse(inputCommand[2]);

            if (timesToMove > matrix.GetLength(1))
            {
                timesToMove = timesToMove % matrix.GetLength(1);
            }

            var tempList = new List<int>();

            for (int columns = 0; columns < matrix.GetLength(1); columns++)
            {
                tempList.Add(matrix[row, columns]);
            }

            if (command == "left")
            {
                for (int listItem = 0; listItem < timesToMove; listItem++)
                {
                    var firstElement = tempList[0];
                    tempList.RemoveAt(0);
                    tempList.Insert(tempList.Count, firstElement);
                }
            }
            else
            {
                for (int listItem = 0; listItem < timesToMove; listItem++)
                {
                    var lastElemet = tempList[tempList.Count - 1];
                    tempList.RemoveAt(tempList.Count - 1);
                    tempList.Insert(0, lastElemet);
                }
            }

            for (int column = 0; column < matrix.GetLength(0); column++)
            {
                matrix[row, column] = tempList[column];
            }
        }

        private static void MoveUpOrDown(string[] inputCommand, int[,] matrix)
        {
            var column = int.Parse(inputCommand[0]);
            if (!(0 <= column && column <= matrix.GetLength(1)))
            {
                return;
            }
            var command = inputCommand[1];
            var timesToMove = int.Parse(inputCommand[2]);

            if (timesToMove > matrix.GetLength(0))
            {
                timesToMove = timesToMove % matrix.GetLength(0);
            }

            var tempList = new List<int>();

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                tempList.Add(matrix[rows, column]);
            }

            if (command == "up")
            {
                for (int listItem = 0; listItem < timesToMove; listItem++)
                {
                    var firstElement = tempList[0];
                    tempList.RemoveAt(0);
                    tempList.Insert(tempList.Count, firstElement);
                } 
            }
            else
            {
                for (int listItem = 0; listItem < timesToMove; listItem++)
                {
                    var lastElemet = tempList[tempList.Count - 1];
                    tempList.RemoveAt(tempList.Count - 1);
                    tempList.Insert(0, lastElemet);
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                matrix[rows, column] = tempList[rows];
            }
        }
    }
}
