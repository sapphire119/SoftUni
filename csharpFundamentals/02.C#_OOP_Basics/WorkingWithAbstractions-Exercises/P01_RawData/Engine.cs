public class Engine
{
    private decimal speed;
    private decimal power;

    public Engine() { }

    public Engine(decimal speed, decimal power)
        : this()
    {
        this.Speed = speed;
        this.Power = power;
    }

    public decimal Power
    {
        get
        {
            return this.power;
        }
        set
        {
            this.power = value;
        }
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

}