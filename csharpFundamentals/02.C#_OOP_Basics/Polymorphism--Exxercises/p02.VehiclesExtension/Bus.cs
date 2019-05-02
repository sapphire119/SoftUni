using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumtptionPerKm, double tankCapacity)
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
            base.FuelConsumtptionInLitersPerKm = value;
        }
    }

    public void SwitchFuelConsumption(double amount)
    {
        this.FuelConsumtptionInLitersPerKm = amount;
    }
}