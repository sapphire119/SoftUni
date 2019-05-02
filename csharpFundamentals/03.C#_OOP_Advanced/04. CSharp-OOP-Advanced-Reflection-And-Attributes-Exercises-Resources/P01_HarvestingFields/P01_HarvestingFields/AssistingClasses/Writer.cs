using System;

public class Writer : IWriter
{
    public void WriteLine<T>(T element)
    {
        Console.WriteLine(element);
    }
}