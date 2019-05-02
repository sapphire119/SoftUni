namespace _02.LineNumbers
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var streamReader = new StreamReader("./../streams/text.txt"))
            {
                using (var streamWriter = new StreamWriter("output.txt"))
                {
                    string line;
                    var lineNumber = 1;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"Line {lineNumber++}: {line}");
                    }
                }
            }
        }
    }
}
