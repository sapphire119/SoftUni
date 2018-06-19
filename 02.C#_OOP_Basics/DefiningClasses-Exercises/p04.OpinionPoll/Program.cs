using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());

        var people = new List<Person>();

        for (int count = 0; count < lines; count++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var personName = input[0];
            var personAge = int.Parse(input[1]);

            var currentPerson = new Person(personName, personAge);

            people.Add(currentPerson);
        }

        people = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

        Console.WriteLine(string.Join(Environment.NewLine,people));
    }
}

