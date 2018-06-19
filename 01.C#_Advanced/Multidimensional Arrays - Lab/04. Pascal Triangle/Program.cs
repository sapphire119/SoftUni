namespace _04._Pascal_Triangle
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var rowsCounter = long.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rowsCounter][];
            long[] sizes = new long[rowsCounter];
            for (int rows = 0; rows < jaggedArray.Length; rows++)
            {
                for (int columns = 0; columns <= rows; columns++)
                {
                    sizes[rows]++;
                }
            }

            for (int sizeOfArray = 1; sizeOfArray <= sizes.Length; sizeOfArray++)
            {
                jaggedArray[sizeOfArray - 1] = new long[sizeOfArray];
            }

            jaggedArray[0][0] = 1;

            long previousValue = 0;
            long currentValue = 0;
            for (int rows = 1; rows < jaggedArray.Length; rows++)
            {
                for (int columns = 0; columns < jaggedArray[rows].Length; columns++)
                {
                    if (columns - 1 < 0)
                    {
                        previousValue = 0;
                        currentValue = jaggedArray[rows - 1][columns];
                    }
                    else if (columns == rows)
                    {
                        previousValue = jaggedArray[rows - 1][columns - 1];
                        currentValue = 0;
                    }
                    else
                    {
                        previousValue = jaggedArray[rows - 1][columns - 1];
                        currentValue = jaggedArray[rows - 1][columns];
                    }

                    jaggedArray[rows][columns] = previousValue + currentValue;

                    previousValue = 0;
                    currentValue = 0;
                }
            }

            for (int rows = 0; rows < jaggedArray.Length; rows++)
            {
                for (int columns = 0; columns < jaggedArray[rows].Length; columns++)
                {
                    Console.Write("{0} ",jaggedArray[rows][columns]);
                }
                Console.WriteLine();
            }

            //Авторско
            int height = int.Parse(Console.ReadLine());
            int[][] triangle = new int[height][];
            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                triangle[currentHeight] = new int[currentHeight + 1];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentHeight] = 1;
                if (currentHeight > 1)
                {
                    for (int width = 1; width < currentHeight; width++)
                    {
                        triangle[currentHeight][width] = triangle[currentHeight - 1][width - 1] + triangle[currentHeight - 1][width];
                    }
                }
            }

            for (int rows = 0; rows < jaggedArray.Length; rows++)
            {
                for (int columns = 0; columns < jaggedArray[rows].Length; columns++)
                {
                    Console.Write("{0} ",jaggedArray[rows][columns]);
                }
                Console.WriteLine();
            }
        }
    }
}
