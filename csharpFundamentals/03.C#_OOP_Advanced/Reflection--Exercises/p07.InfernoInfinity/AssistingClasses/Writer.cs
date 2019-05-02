using System;

public class Writer : IWriteable
{
    public void WriteLine<T>(T element)
    {
        Console.WriteLine(element);
    }
}