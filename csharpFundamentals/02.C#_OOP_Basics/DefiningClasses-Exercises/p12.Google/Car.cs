public class Car
{
    private string model;
    private decimal speed;

    public Car() { }

    public Car(string model, decimal speed)
        : this()
    {
        this.Model = model;
        this.Speed = speed;
    }

    public decimal Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            this.speed = value;
        }
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            this.model = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}