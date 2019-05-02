using System;

public class Reader : IReadable
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}