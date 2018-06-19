namespace _09._Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndColumns = Console.ReadLine().Split().Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToArray();

            var rowsCount = rowsAndColumns[0];
            var columnsCount = rowsAndColumns[1];

            List<List<int>> matrix = new List<List<int>>();

            var number = 0;
            for (int rows = 0; rows < rowsCount; rows++)
            {
                matrix.Add(new List<int>());
                for (int columns = 0; columns < columnsCount; columns++)
                {
                    number++;
                    matrix[rows].Add(number);
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                var commandArgs = command.Split();

                var shotRow = int.Parse(commandArgs[0]);
                var shotColumn = int.Parse(commandArgs[1]);
                var shotRadius = int.Parse(commandArgs[2]);

                for (int rows = 0; rows < matrix.Count; rows++)
                {
                    for (int columns = 0; columns < matrix[rows].Count; columns++)
                    {
                        if ((rows == shotRow && Math.Abs(columns - shotColumn) <= shotRadius) ||
                            (columns == shotColumn && Math.Abs(rows - shotRow) <= shotRadius))
                        {
                            matrix[rows][columns] = 0;
                        }
                    }
                }

                for (int rows = 0; rows < matrix.Count; rows++)
                {
                    matrix[rows].RemoveAll(n => n == 0);
                    if (matrix[rows].Count == 0)
                    {
                        matrix.RemoveAt(rows);
                        rows--;
                    }
                }
            }

            for (int rows = 0; rows < matrix.Count; rows++)
            {
                Console.WriteLine(string.Join(" ",matrix[rows]));
            }
        }
    }
}
