public class Person
{
    private string firstName;
    private string lastName;
    private string birthday;

    public Person() { }

    public Person(string firstName, string lastName)
        : this()
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Birthday = @"n/a";
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

}