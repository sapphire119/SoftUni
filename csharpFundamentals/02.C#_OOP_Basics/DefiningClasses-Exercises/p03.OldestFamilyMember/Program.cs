using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());

        var family = new Family();

        for (int count = 0; count < lines; count++)
        {
            var input = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            var personName = input[0];
            var personAge = int.Parse(input[1]);
            var currentPerson = new Person(personName, personAge);

            family.AddMember(currentPerson);
        }

        var oldestPerson = family.GetOldestMember();
        Console.WriteLine(oldestPerson);
    }
}

