using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumtptionPerKm, double tankCapacity) 
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
            base.FuelConsumtptionInLitersPerKm = value + 0.9;
        }
    }
}