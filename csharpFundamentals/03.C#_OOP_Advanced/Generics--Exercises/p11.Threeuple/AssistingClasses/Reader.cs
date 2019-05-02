using System;

public class Reader : IReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public string[] SplitLine()
    {
        return Console.ReadLine().Split();
    }
}