using System;

public class Truck : Automobile
{
    public Truck(double fuelQuantity, double fuelConsumtptionPerKm)
        : base(fuelQuantity, fuelConsumtptionPerKm)
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
        base.FuelQuantity += (fuelAmount * 0.95);
    }
}