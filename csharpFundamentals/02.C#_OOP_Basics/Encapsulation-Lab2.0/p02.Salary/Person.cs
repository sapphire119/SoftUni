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
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public int Age => this.age;

    public string LastName => this.lastName;

    public string FirstName => this.firstName;

    public decimal Salary => this.salary;

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