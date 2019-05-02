using System;

public class Writer : IWriter
{
    public void WriteLine<T>(T item)
    {
        Console.WriteLine(item);
    }
}