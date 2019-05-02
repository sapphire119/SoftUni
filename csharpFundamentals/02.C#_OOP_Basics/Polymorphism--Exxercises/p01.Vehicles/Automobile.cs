public abstract class Automobile : IAutomobile
{
    private double fuelQuantity;
    private double fuelConsumtptionPerKm;
    private double distanceTraveled;

    public Automobile(double fuelQuantity, double fuelConsumtptionPerKm)
    {
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

    public abstract void Refuel(double fuelAmount);

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