namespace Vampire_Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            int[] rowsAndColumn = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = rowsAndColumn[0];
            int columnsCount = rowsAndColumn[1];
            char[][] matrix = new char[rowsCount][];
            int playerRow = 0;
            int playerColumn = 0;
            for (int rows = 0; rows < rowsCount; rows++)
            {
                string inputRow = Console.ReadLine();
                matrix[rows] = new char[inputRow.Length];
                for (int cols = 0; cols < columnsCount; cols++)
                {
                    matrix[rows][cols] = inputRow[cols];
                    if (matrix[rows][cols] == 'P')
                    {
                        playerRow = rows;
                        playerColumn = cols;
                    }
                }
            }
            string moves = Console.ReadLine();
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'U':
                        PlayerMoveUp(matrix, rowsCount, columnsCount, playerRow, playerColumn);
                        break;
                        // case 'D':
                        //     PlayerMoveDown(matrix, R, C, personCol, personRow);
                        //     break;
                        // case 'L':
                        //     PlayerMoveLeft(matrix, R, C, personCol, personRow);
                        //     break;
                        // case 'R':
                        //     PlayerMoveRight(matrix, R, C, personCol, personRow);
                        //     break;
                }
            }
        }

        private static void PlayerMoveUp(char[][] matrix, int row, int column, int playerRow, int playerColumn)
        {
            int win = 0;
            int loss = 0;
            if (playerRow - 1 < 0)
            {
                win++;
            }
            else
            {
                if (matrix[playerRow - 1][playerColumn] == 'B')
                {
                    char temp = matrix[playerRow][playerColumn];
                    matrix[playerRow][playerColumn] = matrix[playerRow - 1][playerColumn];
                    matrix[playerRow - 1][playerColumn] = temp;
                    playerRow = playerRow - 1;
                    loss++;
                }
                else if (matrix[playerRow - 1][playerColumn] == '.')
                {
                    char temp = matrix[playerRow][playerColumn];
                    matrix[playerRow][playerColumn] = matrix[playerRow - 1][playerColumn];
                    matrix[playerRow - 1][playerColumn] = temp;
                    playerRow = playerRow - 1;
                }
            }

            BunniesExpand(matrix, row, column);

            if ((matrix[playerRow][playerColumn] == 'B' && win != 0) || win != 0)
            {
                PrintVictory(playerColumn, playerRow, matrix);
            }
            if (matrix[playerRow][playerColumn] == 'B' || loss != 0)//matrix[personRow][personCol] != 'P' || loss != 0)
            {
                PrintDefeat(playerColumn, playerRow, matrix);
            }
            
        }

        private static void PrintDefeat(int personCol, int personRow, char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
            Console.WriteLine($"dead: {personRow} {personCol}");
            Environment.Exit(0);
        }

        private static void PrintVictory(int personCol, int personRow, char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
            Console.WriteLine($"won: {personRow} {personCol}");
            Environment.Exit(0);
        }

        private static void BunniesExpand(char[][] matrix, int R, int C)
        {
            for (int rows = 0; rows < R; rows++)
            {
                for (int cols = 0; cols < C; cols++)
                {
                    if (rows == 0 && cols == 0 && matrix[rows][cols] == 'B')                                           //corner
                    {
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        continue;
                    }
                    if (rows == 0 && cols == C - 1 && matrix[rows][cols] == 'B')                                         //corner
                    {
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        continue;
                    }
                    if (rows == R - 1 && cols == 0 && matrix[rows][cols] == 'B')                                    //corner
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        continue;
                    }
                    if (rows == R - 1 && cols == C - 1 && matrix[rows][cols] == 'B')                                  //corner
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        continue;
                    }
                    if (rows == 0 && matrix[rows][cols] == 'B')                                             //sides
                    {
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        continue;
                    }
                    if (rows == R - 1 && matrix[rows][cols] == 'B')                                             //sides
                    {
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        continue;
                    }
                    if (cols == 0 && matrix[rows][cols] == 'B')                                             //sides
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        continue;
                    }
                    if (cols == C - 1 && matrix[rows][cols] == 'B')                                             //sides
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        continue;
                    }
                    if (matrix[rows][cols] == 'B')                                             //center
                    {
                        if (matrix[rows - 1][cols] != 'B')
                        {
                            matrix[rows - 1][cols] = 'b';
                        }
                        if (matrix[rows + 1][cols] != 'B')
                        {
                            matrix[rows + 1][cols] = 'b';
                        }
                        if (matrix[rows][cols - 1] != 'B')
                        {
                            matrix[rows][cols - 1] = 'b';
                        }
                        if (matrix[rows][cols + 1] != 'B')
                        {
                            matrix[rows][cols + 1] = 'b';
                        }
                        continue;
                    }
                }
            }
            for (int rows = 0; rows < R; rows++)
            {
                for (int cols = 0; cols < C; cols++)
                {
                    if (matrix[rows][cols] == 'b')
                        matrix[rows][cols] = 'B';
                }
            }
        }
    }
}