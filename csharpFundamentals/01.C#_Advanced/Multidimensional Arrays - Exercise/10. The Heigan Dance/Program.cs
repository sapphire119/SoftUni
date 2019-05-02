namespace _10._The_Heigan_Dance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var damageDoneEachTurn = decimal.Parse(Console.ReadLine());

            string[,] heiganChamber = new string[15, 15];

            var playerHp = 18500M;
            var heiganHp = 3000000M;

            int initialPlayerRowPosition = 7, initialPlayerColumnPosition = 7;

            for (int rows = 0; rows < heiganChamber.GetLength(0); rows++)
            {
                for (int columns = 0; columns < heiganChamber.GetLength(1); columns++)
                {
                    heiganChamber[rows, columns] = ".";
                }
            }

            heiganChamber[initialPlayerRowPosition, initialPlayerColumnPosition] = "P";

            var cloudDamage = 3500M;
            var eruptionDamage = 6000M;
            var isPlagueCloudActive = false;

            var gameStatus = string.Empty;
            var cloudIndexes = new AffectedColumns();
            while (gameStatus != "finished")
            {
                var commandArgs = Console.ReadLine().Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

                if (isPlagueCloudActive)
                {
                    RemoveCloud(cloudIndexes, playerHp, heiganChamber, initialPlayerRowPosition, initialPlayerColumnPosition, cloudDamage);
                    isPlagueCloudActive = false;
                }

                var spell = commandArgs[0];

                var hitSpellRow = int.Parse(commandArgs[1]);
                var hitSpellColumn = int.Parse(commandArgs[2]);

                if (0 <= hitSpellRow && hitSpellRow < heiganChamber.GetLength(0) &&
                    0 <= hitSpellColumn && hitSpellColumn < heiganChamber.GetLength(1))
                {
                    var affectedRowsAndColumns = CalcRowsAndColumns(hitSpellRow, hitSpellColumn, heiganChamber);

                    if (spell == "Cloud")
                    {
                        isPlagueCloudActive = true;
                        cloudIndexes = affectedRowsAndColumns;

                       var doesPlayerHaveToMove = CastCloud(heiganHp, playerHp, initialPlayerRowPosition, initialPlayerColumnPosition, affectedRowsAndColumns, heiganChamber, cloudDamage);

                        var playerRowAndColumn = string.Empty;

                        if (doesPlayerHaveToMove)
                        {
                            playerRowAndColumn = MovePlayer(affectedRowsAndColumns, initialPlayerColumnPosition, initialPlayerRowPosition, heiganChamber);

                            var playerArgs = playerRowAndColumn.Split().Select(int.Parse).ToArray();
                            initialPlayerRowPosition = playerArgs[0];
                            initialPlayerColumnPosition = playerArgs[1];
                        }
                    }
                    else if (spell == "Eruption")
                    {

                    }
                }
            }


            for (int rows = 0; rows < heiganChamber.GetLength(0); rows++)
            {
                for (int columns = 0; columns < heiganChamber.GetLength(1); columns++)
                {
                    Console.Write("{0} ",heiganChamber[rows,columns]);
                }
                Console.WriteLine();
            }
        }

        private static void RemoveCloud(AffectedColumns cloudIndexes, decimal playerHp, string[,] heiganChamber, int initialPlayerRowPosition, int initialPlayerColumnPosition, decimal cloudDamage)
        {
            var startingRow = cloudIndexes.StartingAffectedRow;
            var endingRow = cloudIndexes.EndingAffectedRow;

            var startingColumn = cloudIndexes.StartinAffectedColumn;
            var endingColumn = cloudIndexes.EndingAffectedColumn;

            for (int row = startingRow; row < startingRow + endingRow; row++)
            {
                for (int column = startingColumn; column < endingColumn; column++)
                {
                    if (row == initialPlayerRowPosition && column == initialPlayerColumnPosition)
                    {
                        playerHp -= cloudDamage;
                    }
                    heiganChamber[row, column] = ".";
                }
            }
        }

        private static bool CastCloud
            (decimal heiganHp, decimal playerHp, int initialPlayerRowPosition, int initialPlayerColumnPosition,
            AffectedColumns affectedRowsAndColumns, string[,] heiganChamber, decimal cloudDamage)
        {
            var doesPlayerHaveToMove = false;

            var startingRow = affectedRowsAndColumns.StartingAffectedRow;
            var endingRow = affectedRowsAndColumns.EndingAffectedRow;

            var startingColumn = affectedRowsAndColumns.StartinAffectedColumn;
            var endingColumn = affectedRowsAndColumns.EndingAffectedColumn;
            for (int row = startingRow; row < startingRow + endingRow; row++)
            {
                
                for (int column = startingColumn; column < startingColumn + endingColumn; column++)
                {
                    if (row == initialPlayerRowPosition && column == initialPlayerColumnPosition)
                    {
                        doesPlayerHaveToMove = true;
                        playerHp -= cloudDamage;
                    }
                    heiganChamber[row, column] = "C";
                }
            }

            return doesPlayerHaveToMove;
        }

        private static string MovePlayer(AffectedColumns affectedRowsAndColumns, int playerColumn, int playerRow, string[,] heiganChamber)
        {
            var startingRow = affectedRowsAndColumns.StartingAffectedRow;
            var endingRow = affectedRowsAndColumns.EndingAffectedRow;
            var startingColumn = affectedRowsAndColumns.StartinAffectedColumn;
            var endingColumn = affectedRowsAndColumns.EndingAffectedColumn;


            if (heiganChamber[startingRow, playerColumn] != "C")
            {
                playerRow = startingRow;
            }
            else if (heiganChamber[playerRow, endingColumn] != "C")
            {
                playerColumn = endingColumn;
            }
            else if (heiganChamber[endingRow, playerColumn] != "C")
            {
                playerRow = endingRow;
            }
            else if (heiganChamber[playerRow, startingColumn] != "C")
            {
                playerColumn = startingColumn;
            }

            return $"{playerRow} {playerColumn}";
        }

        private static AffectedColumns CalcRowsAndColumns(int hitSpellRow, int hitSpellColumn, string[,] heiganChamber)
        {
            var startingAffectedRow = hitSpellRow - 1;
            if (startingAffectedRow < 0)
            {
                startingAffectedRow = hitSpellRow;
            }
            var endingAffectedRow = hitSpellRow + 1;
            if (endingAffectedRow >= heiganChamber.GetLength(0))
            {
                endingAffectedRow = heiganChamber.GetLength(0) - 1;
            }
            var startingAffectedColumn = hitSpellColumn - 1;
            if (startingAffectedColumn < 0)
            {
                startingAffectedColumn = hitSpellColumn;
            }
            var endingAffectedColumn = hitSpellColumn + 1;
            if (endingAffectedColumn >= heiganChamber.GetLength(1))
            {
                endingAffectedColumn = heiganChamber.GetLength(1) - 1;
            }

            var affectedColumns = new AffectedColumns(startingAffectedColumn, endingAffectedColumn, startingAffectedRow, endingAffectedRow);

            return affectedColumns;

        }

        public class AffectedColumns
        {
            private int startingRow;
            private int endingRow;
            private int startingColumn;
            private int endingColumn;

            public AffectedColumns() { }

            public AffectedColumns(int startingColumn, int endingColumn, int startingRow, int endingRow)
            {
                this.StartingAffectedRow = startingRow;
                this.EndingAffectedRow = endingRow;
                this.StartinAffectedColumn = startingColumn;
                this.EndingAffectedColumn = endingColumn;
            }

            public int StartingAffectedRow
            {
                get
                {
                    return this.startingRow;
                }
                set
                {
                    this.startingRow = value;
                }
            }

            public int EndingAffectedRow
            {
                get
                {
                    return this.endingRow;
                }
                set
                {
                    this.endingRow = value;
                }
            }

            public int StartinAffectedColumn
            {
                get
                {
                    return this.startingColumn;
                }
                set
                {
                    this.startingColumn = value;
                }
            }

            public int EndingAffectedColumn
            {
                get
                {
                    return this.endingColumn;
                }
                set
                {
                    this.endingColumn = value;
                }
            }
        }
    }
}
