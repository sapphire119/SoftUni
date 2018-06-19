using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumtptionPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumtptionPerKm, tankCapacity)
    {
    }

    public override double FuelConsumtptionInLitersPerKm
    {
        get
        {
            return base.FuelConsumtptionInLitersPerKm;
        }
        protected set
        {
            base.FuelConsumtptionInLitersPerKm = value + 1.6;
        }
    }

    public override void Refuel(double fuelAmount)
    {
        ValidateFuelAmount(fuelAmount);
        base.FuelQuantity += (fuelAmount * 0.95);
    }
}