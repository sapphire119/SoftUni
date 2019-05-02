namespace _02._Sneaking
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static int samsRow;

        public static void Main()
        {
            var roomSize = int.Parse(Console.ReadLine());

            List<char>[] roomMatrix = new List<char>[roomSize];

            for (int i = 0; i < roomMatrix.GetLength(0); i++)
            {
                roomMatrix[i] = new List<char>();
            }

            var samsRow = 0;
            var samsColumn = 0;

            var nikoladzeRow = 0;
            var nikoladzeColumn = 0;

            for (int rows = 0; rows < roomMatrix.GetLength(0); rows++)
            {
                var input = Console.ReadLine();
                for (int index = 0; index < input.Length; index++)
                {
                    roomMatrix[rows].Add(input[index]);
                    if (roomMatrix[rows][index] == 'S')
                    {
                        samsRow = rows;
                        samsColumn = index;
                    }
                    if (roomMatrix[rows][index] == 'N')
                    {
                        nikoladzeRow = rows;
                        nikoladzeColumn = index;
                    }
                }
            }


            var commands = Console.ReadLine();

            for (int count = 0; count < commands.Length; count++)
            {
                MoveEnemies(roomMatrix);

                var currentCommand = commands[count];

                bool isSamDead = CheckForKillers(roomMatrix, samsRow, samsColumn);
                if (isSamDead)
                {
                    PrintSamsDeathMessage(samsRow, samsColumn, roomMatrix);
                    break;
                }

                MovePlayer(roomMatrix, ref samsRow, ref samsColumn, currentCommand);

                if (nikoladzeRow == samsRow)
                {
                    PrintNikoladzesDeath(roomMatrix, nikoladzeRow, nikoladzeColumn);
                    break;
                }
            }

            for (int rows = 0; rows < roomMatrix.GetLength(0); rows++)
            {
                Console.WriteLine(string.Join("", roomMatrix[rows]));
            }
        }

        private static void MovePlayer(List<char>[] roomMatrix, ref int samsRow, ref int samsColumn, char currentCommand)
        {
            if (currentCommand == 'U' || currentCommand == 'D')
            {
                samsRow = MoveSamByRow(roomMatrix, samsRow, samsColumn, currentCommand);
            }
            else if (currentCommand == 'L' || currentCommand == 'R')
            {
                samsColumn = MoveSamByColumn(roomMatrix, samsRow, samsColumn, currentCommand);
            }
        }

        private static void PrintNikoladzesDeath(List<char>[] roomMatrix, int nikoladzeRow, int nikoladzeColumn)
        {
            roomMatrix[nikoladzeRow][nikoladzeColumn] = 'X';
            Console.WriteLine("Nikoladze killed!");
        }

        private static int MoveSamByColumn(List<char>[] roomMatrix, int samsRow, int samsColumn, char currentCommand)
        {
            var columnIndex = 0;
            switch (currentCommand)
            {
                case 'L': columnIndex = 1; break;
                case 'R': columnIndex = -1; break;
                default:
                    break;
            }
            roomMatrix[samsRow][samsColumn] = '.';
            samsColumn -= columnIndex;
            roomMatrix[samsRow][samsColumn] = 'S';
            return samsColumn;
        }

        private static int MoveSamByRow(List<char>[] roomMatrix, int samsRow, int samsColumn, char currentCommand)
        {
            var directionRowIndex = 0;
            switch (currentCommand)
            {
                case 'U': directionRowIndex = 1; break;
                case 'D': directionRowIndex = -1; break;
                default:
                    break;
            }

            roomMatrix[samsRow][samsColumn] = '.';
            samsRow -= directionRowIndex;
            roomMatrix[samsRow][samsColumn] = 'S';
            return samsRow;
        }

        private static void PrintSamsDeathMessage(int samsRow, int samsColumn, List<char>[] roomMatrix)
        {
            roomMatrix[samsRow][samsColumn] = 'X';
            Console.WriteLine($"Sam died at {samsRow}, {samsColumn}");
        }

        private static bool CheckForKillers(List<char>[] roomMatrix, int samsRow, int samsColumn)
        {
            var isSamDead = false;
            for (int columns = 0; columns < samsColumn; columns++)
            {
                if (roomMatrix[samsRow][columns] == 'b')
                {
                    roomMatrix[samsRow][samsColumn] = 'X';
                    isSamDead = true;
                    break;
                }
            }

            for (int columns = samsColumn; columns < roomMatrix[samsRow].Count; columns++)
            {
                if (roomMatrix[samsRow][columns] == 'd')
                {
                    roomMatrix[samsRow][samsColumn] = 'X';
                    isSamDead = true;
                    break;
                }
            }

            return isSamDead;
        }

        private static void MoveEnemies(List<char>[] roomMatrix)
        {
            for (int rows = 0; rows < roomMatrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < roomMatrix[rows].Count; columns++)
                {
                    if (roomMatrix[rows][columns] == 'b')
                    {
                        if (columns == roomMatrix[rows].Count - 1)
                        {
                            roomMatrix[rows][columns] = 'd';
                            break;
                        }
                        roomMatrix[rows][columns + 1] = roomMatrix[rows][columns];
                        roomMatrix[rows][columns] = '.';
                        break;
                    }
                    if (roomMatrix[rows][columns] == 'd')
                    {
                        if (columns == 0)
                        {
                            roomMatrix[rows][columns] = 'b';
                            break;
                        }
                        roomMatrix[rows][columns - 1] = roomMatrix[rows][columns];
                        roomMatrix[rows][columns] = '.';
                        break;
                    }
                }
            }
        }
    }
}
