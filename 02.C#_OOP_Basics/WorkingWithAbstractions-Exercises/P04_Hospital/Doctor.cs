using System.Collections.Generic;

public class Doctor
{
    private List<string> pacients;
    private string firstName;
    private string lastName;

    public Doctor()
    {
        this.Pacients = new List<string>();
    }

    public Doctor(string firstName, string lastName)
        : this()
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            this.lastName = value;
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
            this.firstName = value;
        }
    }

    public List<string> Pacients
    {
        get
        {
            return this.pacients;
        }
        set
        {
            this.pacients = value;
        }
    }

}