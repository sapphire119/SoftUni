using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person() { }

    public Person(string firstName, string lastName, int age, decimal salary)
        : this()
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw Exceptions.ageException;
            }
            this.age = value;
        }
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name" + Exceptions.nameException.Message);
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name" + Exceptions.nameException.Message);
            }
            this.lastName = value;
        }
    }


    public decimal Salary
    {
        get
        {
            return this.salary;
        }
        set
        {
            if (value < 460.0M)
            {
                throw Exceptions.salaryException;
            }
            this.salary = value;
        }
    }

    public void IncreaseSalary(decimal percentage)
    {
        percentage = this.Age < 30 ? (percentage / 2.0M) : percentage;

        this.salary += this.Salary * (percentage / 100.0M);
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }
}