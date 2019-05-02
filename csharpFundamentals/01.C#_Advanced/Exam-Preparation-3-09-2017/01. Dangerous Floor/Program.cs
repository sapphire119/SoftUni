namespace _01._Dangerous_Floor
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] chessBoard = new string[8, 8];

            for (int rows = 0; rows < chessBoard.GetLength(0); rows++)
            {
                var input = Console.ReadLine().Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

                for (int columns = 0; columns < chessBoard.GetLength(1); columns++)
                {
                    chessBoard[rows, columns] = input[columns];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var typeOfPiece = command.Substring(0, 1);
                var currentPosition = command.Substring(1, 2);
                var nextPosition = command.Substring(4);

                ExecuteCommands(typeOfPiece, currentPosition, nextPosition, chessBoard);
            }
        }

        private static void ExecuteCommands(string typeOfPiece, string currentPosition, string nextPosition, string[,] chessBoard)
        {
            var currentRow = int.Parse(currentPosition[0].ToString());
            var currentColumn = int.Parse(currentPosition[1].ToString());

            bool checkCurrentRow = (0 <= currentRow && currentRow < chessBoard.GetLength(0));
            bool checkCurrentColumn = (0 <= currentColumn && currentColumn < chessBoard.GetLength(1));

            if (!checkCurrentRow || !checkCurrentColumn) 
            {
                return;
            }

            if (chessBoard[currentRow, currentColumn] != typeOfPiece)
            {
                Console.WriteLine("There is no such a piece!");
                return;
            }

            var nextRow = int.Parse(nextPosition[0].ToString());
            var nextColumn = int.Parse(nextPosition[1].ToString());

            bool checkNextRow = (0 <= nextRow && nextRow < chessBoard.GetLength(0));
            bool checkNextColumn = (0 <= nextColumn && nextColumn < chessBoard.GetLength(1));

            if (!checkNextRow || !checkNextColumn)
            {
                Console.WriteLine("Move go out of board!");
                return;
            }

            bool isMoveValid = IsMoveValid(typeOfPiece, currentRow, currentColumn, nextRow, nextColumn, chessBoard);

            if (!isMoveValid)
            {
                Console.WriteLine("Invalid move!");
                return;
            }

            var oldSquare = chessBoard[currentRow, currentColumn];
            chessBoard[currentRow, currentColumn] = chessBoard[nextRow, nextColumn];
            chessBoard[nextRow, nextColumn] = oldSquare;
        }

        private static bool IsMoveValid(string typeOfPiece, int currentRow, int currentColumn, int nextRow, int nextColumn, string[,] chessBoard)
        {
            var isMoveValid = true;
            if (typeOfPiece == "K")
            {
                var startingRow = currentRow - 1;
                var startingColumn = currentColumn - 1;

                var endingRow = currentRow + 1;
                var endingColumn = currentColumn + 1;

                if (!(startingRow <= nextRow && nextRow <= endingRow && startingColumn <= nextColumn && nextColumn <= endingColumn))
                {
                    isMoveValid = false;
                }
            }
            else if (typeOfPiece == "R")
            {
                var startingRow = 0;
                var startingColumn = 0;

                var endingRow = chessBoard.GetLength(0);
                var endingColumn = chessBoard.GetLength(1);

                bool checkRow = (startingRow <= nextRow && nextRow <= endingRow && currentColumn == nextColumn);
                bool checkColumn = (startingColumn <= nextColumn && nextColumn <= endingColumn && currentRow == nextRow);
                if (!checkRow && !checkColumn)
                {
                    isMoveValid = false;
                }
            }
            else if (typeOfPiece == "B")
            {
                bool checkMainDiagonal = nextRow - nextColumn == (currentRow - currentColumn);
                bool reverseDiagaonal = nextRow + nextColumn == (currentRow + currentColumn);
                if (!checkMainDiagonal && !reverseDiagaonal)
                {
                    isMoveValid = false;
                }
            }
            else if (typeOfPiece == "Q")
            {
                var startingRow = 0;
                var startingColumn = 0;

                var endingRow = chessBoard.GetLength(0);
                var endingColumn = chessBoard.GetLength(1);

                bool checkRow = (startingRow <= nextRow && nextRow <= endingRow && currentColumn == nextColumn);
                bool checkColumn = (startingColumn <= nextColumn && nextColumn <= endingColumn && currentRow == nextRow);

                bool checkMainDiagonal = nextRow - nextColumn == (currentRow - currentColumn);
                bool reverseDiagaonal = nextRow + nextColumn == (currentRow + currentColumn);

                if (!checkMainDiagonal && !reverseDiagaonal && !checkRow && !checkColumn)
                {
                    isMoveValid = false;
                }
            }
            else if (typeOfPiece == "P")
            {
                var rowDiffrence = currentRow - nextRow;
                if (rowDiffrence != 1 || currentColumn != nextColumn)
                {
                    isMoveValid = false;
                }
            }
            return isMoveValid;
        }
    }
}
