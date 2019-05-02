using System;

public class Program
{
    public static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var dateModifier = new DateModifier(firstDate, secondDate);

        Console.WriteLine(dateModifier.CalculateDiffrence());
    }
}

