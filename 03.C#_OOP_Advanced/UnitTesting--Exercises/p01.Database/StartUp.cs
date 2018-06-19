using System;

public class StartUp
{
    public static void Main()
    {
        var person = new Person(1, "pesho");
        var person1 = new Person(2, "gosho");

        ExtendedDatabase db = new ExtendedDatabase(person, person1);
    }
}

