using System;

public class Child
{
    private string name;
    private string birthday;

    public Child() { }

    public Child(string name, string birthday)
        : this()
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public string Birthday
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
        return $"{this.Name} {this.Birthday}";
    }
}