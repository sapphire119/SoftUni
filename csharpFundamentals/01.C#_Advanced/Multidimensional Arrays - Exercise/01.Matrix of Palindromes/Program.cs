namespace _01.Matrix_of_Palindromes
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var rowsAndColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rowsCount = rowsAndColumns[0];
            var columnCount = rowsAndColumns[1];

            int[,] matrix = new int[rowsCount, columnCount];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    Console.Write("{0}{1}{2} ",alphabet[rows],alphabet[rows + columns],alphabet[rows]);
                }
                Console.WriteLine();
            }
        }
    }
}
