using System;

public class Child : Person
{
    private const int MinAgeForChild = 15;
    private const string AgeError = "Child's age must be less than {0}!";

    public Child(string name, int age)
        :base(name, age) { }

    public override int Age
    {
        get => base.Age;
        set
        {
            if (value > MinAgeForChild)
            {
                throw new ArgumentException(string.Format(AgeError, MinAgeForChild));
            }
            base.Age = value;
        }
    }
}