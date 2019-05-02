using System;

public abstract class Provider : IProvider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }
        protected set
        {
            ValidateEnergyOutput(value);
            this.energyOutput = value;
        }
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        private set
        {
            this.id = value;
        }
    }


    private void ValidateEnergyOutput(double number)
    {
        if (number <= 0.0 || number >= 10_000.0)
        {
            throw new ArgumentException();
        }
    }
}