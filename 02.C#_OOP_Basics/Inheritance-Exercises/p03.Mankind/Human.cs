using System;
using System.Collections.Generic;
using System.Text;

public class Human
{
    private const int MinFirstNameLength = 4;
    private const int MinLastNameLength = 3;

    private const string nameFirstLetterError = "Expected upper case letter! Argument: {0}";
    private const string nameLengthError = "Expected length at least {0} symbols! Argument: {1}";

    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            ValidateName(value, nameof(firstName), MinFirstNameLength);
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
            ValidateName(value, nameof(lastName), MinLastNameLength);
            this.lastName = value;
        }
    }

    private void ValidateName(string value, string type, int minLength)
    {
        if (char.IsLower(value[0]))
        {
            throw new ArgumentException(string.Format(nameFirstLetterError, type));
        }
        else if (value.Length < minLength)
        {
            throw new ArgumentException(string.Format(nameLengthError, minLength, type));
        }
    }

    public override string ToString()
    {
        //First Name: {student's first name}
        //Last Name: { student's last name}
        //Faculty number: { student's faculty number}
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}