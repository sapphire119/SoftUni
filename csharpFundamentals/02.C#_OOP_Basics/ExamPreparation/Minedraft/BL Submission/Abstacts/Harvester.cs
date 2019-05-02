using System;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double energyRequirement, double oreOutput)
    {
        this.Id = id;
        this.EnergyRequirement = energyRequirement;
        this.OreOutput= oreOutput;
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            ValidateOutputEnergy(value, nameof(this.EnergyRequirement));
            this.energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            ValidateOutputEnergy(value, nameof(this.OreOutput));
            this.oreOutput = value;
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

    protected void ValidateOutputEnergy(double number, string param)
    {
        if (number <= 0.0 || (param == nameof(this.EnergyRequirement) && number > 20_000.0))
        {
            throw new ArgumentException();
        }
    }
}