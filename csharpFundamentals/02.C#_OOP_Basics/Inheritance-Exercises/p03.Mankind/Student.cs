using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private const int MinLenghtFacultyNumber = 5;
    private const int MaxLenghtFacultyNumber = 10;
    private const string RegexPattern = @"^[A-Za-z\d]{5,10}$";

    private const string FacultyNumberError = "Invalid faculty number!";

    private string faculltyNumber;

    public Student(string firstName, string lastName, string facultyNumber) 
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.faculltyNumber;
        }
        set
        {
            if (!Regex.IsMatch(value, RegexPattern))
            {
                throw new ArgumentException(FacultyNumberError);
            }
            this.faculltyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Faculty number: {this.FacultyNumber}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}