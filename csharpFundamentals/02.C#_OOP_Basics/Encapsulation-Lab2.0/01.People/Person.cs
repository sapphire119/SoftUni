public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public Person() { }

    public Person(string firstName, string lastName, int age)
        : this()
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public int Age => this.age;

    public string LastName => this.lastName;

    public string FirstName => this.firstName;


    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
    }
}