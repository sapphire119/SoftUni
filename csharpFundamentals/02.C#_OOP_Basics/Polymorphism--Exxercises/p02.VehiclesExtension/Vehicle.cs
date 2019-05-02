using System;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumtptionPerKm;
    private double distanceTraveled;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumtptionPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumtptionInLitersPerKm = fuelConsumtptionPerKm;
        this.DistanceTraveled = 0;
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        protected set
        {
            this.fuelQuantity = value;
        }
    }

    public virtual double FuelConsumtptionInLitersPerKm
    {
        get
        {
            return this.fuelConsumtptionPerKm;
        }
        protected set
        {
            this.fuelConsumtptionPerKm = value;
        }
    }

    public double DistanceTraveled
    {
        get
        {
            return this.distanceTraveled;
        }
        private set
        {
            this.distanceTraveled = value;
        }
    }

    public double TankCapacity
    {
        get
        {
            return this.tankCapacity;
        }
        set
        {
            this.tankCapacity = value;
        }
    }

    public virtual void Refuel(double fuelAmount)
    {
        ValidateFuelAmount(fuelAmount);
        this.FuelQuantity += fuelAmount;
    }

    protected void ValidateFuelAmount(double fuelAmount)
    {
        if (fuelAmount <= 0.0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (this.FuelQuantity + fuelAmount > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
        }
    }

    public string TravelDistance(double distance)
    {
        var fuelConsumedForDistance = this.FuelQuantity - (this.FuelConsumtptionInLitersPerKm * distance);

        if (fuelConsumedForDistance < 0.0)
        {
            return $"{this.GetType().Name} needs refueling";
        }

        this.FuelQuantity = fuelConsumedForDistance;
        this.DistanceTraveled += distance;

        return $"{this.GetType().Name} travelled {distance} km";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}