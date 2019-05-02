namespace _01.Intro
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            PrintTopOfRhombus(input);
            PrintBottomOfRhombus(input);
        }

        private static void PrintBottomOfRhombus(int input)
        {
            for (int rows = 1, timesToPrintStar = input - rows - 1; rows < input && timesToPrintStar >= 0; rows++, timesToPrintStar--)
            {
                for (int columns = 0; columns <= rows; columns++)
                {
                    if (columns == rows)
                    {
                        Console.Write("*");
                        PrintInsideStars(timesToPrintStar);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PrintTopOfRhombus(int input)
        {
            for (int rows = 0, timesToPrintStar = 0; rows < input && timesToPrintStar < input; rows++, timesToPrintStar++)
            {
                for (int columns = 0; columns < input - rows; columns++)
                {
                    if (columns == input - rows - 1)
                    {
                        Console.Write('*');
                        PrintInsideStars(timesToPrintStar);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PrintInsideStars(int timesToPrintStar)
        {
            for (int count = 0; count < timesToPrintStar; count++)
            {
                Console.Write(" *");
            }
        }
    }
}
