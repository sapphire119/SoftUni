using System;

public class Person
{
    private const int MinLenghtName = 3;

    private const string AgeError = "Age must be positive!";
    private const string NameError = "Name's length should not be less than {0} symbols!";

    private int age;
    private string name;

    public Person() { }

    public Person(string name, int age)
        : this()
    {
        this.Name = name;
        this.Age = age;
    }

    public virtual int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(AgeError);
            }
            this.age = value;
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
            if (value.Length < MinLenghtName)
            {
                throw new ArgumentException(string.Format(NameError, MinLenghtName));
            }
            this.name = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}