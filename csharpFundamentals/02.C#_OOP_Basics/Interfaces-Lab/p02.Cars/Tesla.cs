using System.Text;

public class Tesla : Seat, IElectricCar
{
    private int battery;

    public Tesla(string model, string color, int battery) 
        : base(model, color)
    {
        this.battery = battery;
    }

    public int Battery() => this.battery;

    protected override string BatteriesMessage => $" with {this.battery} Batteries";

    public override string ToString()
    {
        return base.ToString();
    }
}