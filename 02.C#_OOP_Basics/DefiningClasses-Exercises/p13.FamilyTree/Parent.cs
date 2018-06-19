public class Parent
{
    private string firstName;
    private string lastName;
    private string birthday;

    public Parent() { }

    public Parent(string firstName, string lastName, string birthday)
        : this()
    {
        this.FirstName = firstName;
        this.LastName = lastName;
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

    public string LastName
    {
        get
        {
            return this.lastName ;
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