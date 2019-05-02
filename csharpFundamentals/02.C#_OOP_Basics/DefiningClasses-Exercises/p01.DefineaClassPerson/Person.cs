public class Person
{ 
    private string name;
    private int age;

    public Person() { }

    public Person(string name, int age)
        :this()
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }


    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

}

