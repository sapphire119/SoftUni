using System;

public class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumptionPerKm;
    private decimal distanceTraveled;

    public Car() { }

    public Car(string model, decimal fuelamount, decimal fuelConsumptionPerKm)
        : this()
    {
        this.Model = model;
        this.FuelAmount = fuelamount;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.DistanceTraveled = 0M;
    }

    public decimal DistanceTraveled
    {
        get
        {
            return this.distanceTraveled;
        }
        set
        {
            this.distanceTraveled = value;
        }
    }

    public decimal FuelConsumptionPerKm
    {
        get
        {
            return this.fuelConsumptionPerKm;
        }
        set
        {
            this.fuelConsumptionPerKm = value;
        }
    }

    public decimal FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }
        set
        {
            this.fuelAmount = value;
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

    public void DriveCar(decimal amountDistance)
    {
        var currentFuelSpentForTravel = amountDistance * this.FuelConsumptionPerKm;
        var fuelAmountLeft = this.FuelAmount - currentFuelSpentForTravel;
        if (fuelAmountLeft >= 0)
        {
            this.FuelAmount = fuelAmountLeft;
            this.DistanceTraveled += amountDistance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {Math.Round(this.FuelAmount, 2):f2} {this.DistanceTraveled}";
    }
}
