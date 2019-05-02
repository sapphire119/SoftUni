public class Citizen : IPerson, IBirthable, IIdentifiable
{
    private string name;
    private int age;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            this.age = value;
        }
    }

    public string Id { get; private set; }

    public string Birthdate { get; private set; }
}
