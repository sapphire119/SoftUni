namespace _01.OddLines
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var streamReader = new StreamReader("./../streams/text.txt"))
            {
                string line;
                var count = 0;
                while ((line = streamReader.ReadLine()) != null) 
                {
                    if (count % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    count++;
                }
            }
        }
    }
}
