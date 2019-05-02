using System;

public class StartUp
{
    public static void Main()
    {
        IPerson fstPerson = new Person(1, "pesho");
        IPerson sndPerson = new Person(2, "ivan");
        IPerson thrdPerson = new Person(3, "gosho");
        IPerson frthPerson = new Person(4, "stamat");
        IPerson fifthPerson = new Person(5, "iordan");

        IExtendedDatabase database = new ExtendedDatabase(fstPerson, sndPerson, thrdPerson, frthPerson, fifthPerson);

        IPerson randomPerson = new Person(66, "Nqkuv");
        IPerson randomPerson2 = new Person(6, null);
        IPerson randomPerson3 = new Person(7, "Peshonito");
        IPerson randomPerson4 = new Person(8, "peshonito");

        //database.Add(randomPerson);
        database.Add(randomPerson3);
        database.Add(randomPerson4);
        var person = database.FindById(5);
    }
}
