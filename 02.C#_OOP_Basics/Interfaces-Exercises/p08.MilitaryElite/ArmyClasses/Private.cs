using System;

public class Private : IPrivate
{
    public Private(int id, string firstName, string lastName, double salary)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Salary = salary;
    }

    public int Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public double Salary { get; private set; }

    public override string ToString()
    {
        var roundedSalary = Math.Round(this.Salary, 2);
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {roundedSalary:F2}";
    }
}