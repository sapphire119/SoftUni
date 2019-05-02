using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people;

    public Family()
    {
        this.People = new List<Person>();
    }

    public Family(List<Person> family)
        : this()
    {
        this.People = people;
    }

    public List<Person> People
    {
        get
        {
            return this.people;
        }
        set
        {
            this.people = value;
        }
    }

    public void AddMember(Person member)
    {
        this.People.Add(member);
    }

    public Person GetOldestMember()
    {
        var personWithMaxAge = this.People.Max(p => p.Age);
        return this.People.Find(p => p.Age == personWithMaxAge);
    }
}