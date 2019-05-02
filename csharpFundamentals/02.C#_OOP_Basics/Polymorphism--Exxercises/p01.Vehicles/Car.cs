using System;

public class Car : Automobile
{
    public Car(double fuelQuantity, double fuelConsumtptionPerKm)
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
            base.FuelConsumtptionInLitersPerKm = value + 0.9;
        }
    }

    public override void Refuel(double fuelAmount)
    {
        base.FuelQuantity += fuelAmount;
    }
}