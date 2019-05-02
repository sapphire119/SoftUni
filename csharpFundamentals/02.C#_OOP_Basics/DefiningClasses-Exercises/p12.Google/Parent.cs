using System;

public class Parent
{
    private string name;
    private string birthday;

    public Parent() { }

    public Parent(string name, string birthday)
        : this()
    {
        this.Name = name;
        this.BirthDay = birthday;
    }
    
    public string BirthDay
    {
        get
        {
            return this.birthday;
        }
        set
        {
            this.birthday = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.BirthDay}";
    }
}

