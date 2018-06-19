public class Tire
{
    private decimal pressure;
    private int age;

    public Tire() { }

    public Tire(decimal pressure, int age) 
        : this()
    {
        this.Pressure = pressure;
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

    public decimal Pressure
    {
        get
        {
            return this.pressure;
        }
        set
        {
            this.pressure = value;
        }
    }
}

