using System;
using System.Text;

public abstract class Provider : Unit, IProvider
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }
        private set
        {
            if (value < 0 || value >= 10_000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Type} Provider - {this.Id}")
            .AppendLine($"Energy Output: {this.EnergyOutput}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}