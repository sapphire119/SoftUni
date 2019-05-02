public abstract class Driver
{
    protected Driver(string name, double totalTime, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = totalTime;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name { get; private set; }

    public double TotalTime { get; set; }

    public Car Car { get; private set; }

    public double FuelConsumptionPerKm { get; private set; }

    public virtual double Speed => ((double)this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public string FailureReason { get; set; }

    public bool IsOutOfRace { get; set; }
}