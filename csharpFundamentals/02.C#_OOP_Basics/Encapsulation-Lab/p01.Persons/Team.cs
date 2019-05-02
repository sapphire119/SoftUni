using System.Linq;
using System.Collections.Generic;

public class Team
{
    private List<Person> people;

    public Team()
    {
        this.people = new List<Person>();
    }

    public IReadOnlyCollection<Person> People
    {
        get
        {
            return new List<Person>(this.people);
        }
    }


    public void AddPerson(Person person)
    {
        this.people.Add(person);
    }
}