using System;

public class Car
{
    private const double TankCapacity = 160.0;

    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }

    public double FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }
        set
        {
            if (value > TankCapacity)
            {
                value = TankCapacity;
            }

            this.fuelAmount = value;

            if (this.fuelAmount < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
        }
    }

    public void Refuel(double fuelAmount)
    {
        //var currentFuel = this.FuelAmount;
        //if (currentFuel + fuelAmount > TankCapacity)
        //{
        //    this.FuelAmount = TankCapacity;
        //    return;
        //}

        this.FuelAmount += fuelAmount;
    }

    public Tyre Tyre { get; private set; }
}