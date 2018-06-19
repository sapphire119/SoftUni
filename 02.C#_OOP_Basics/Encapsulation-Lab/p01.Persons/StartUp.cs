namespace p01.Persons
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            //nameof <<---- What is ?
            
            var team = new Team();

            var person = new Person("Pesho", 24);
            var person1 = new Person("Ivan", 44);
            var person2 = new Person("Gosho", 32);

            team.AddPerson(person);
            team.AddPerson(person1);
            team.AddPerson(person2);

            team.People.First().Name = "New name";

            Console.WriteLine(string.Join(Environment.NewLine, team.People));
        }
    }
}
