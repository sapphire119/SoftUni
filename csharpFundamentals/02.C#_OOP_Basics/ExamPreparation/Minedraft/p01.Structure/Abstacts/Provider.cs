using System;
using System.Text;

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
            ValidateEnergyOutput(value, nameof(this.EnergyOutput));
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


    private void ValidateEnergyOutput(double number, string param)
    {
        if (number < 0.0 || number > 10_000.0)
        {
            throw new ArgumentException(string.Format(Messages.UnsuccessfulProviderRegister, param));
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name} Provider - {this.Id}")
            .AppendLine($"Energy Output: {this.EnergyOutput}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}