using System;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;

    private double durability;
    //private double oreOutput;
    //private double energyRequirement;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability
    {
        get
        {
            return this.durability;
        }
        protected set
        {
            this.durability = value;
            if (this.durability < 0)
            {
                throw new ArgumentException(string.Format(Constants.EntityBroke, this.GetType().Name));
            }
        }
    }

    public void Broke()
    {
        this.Durability -= 100;
    }

    public double Produce()
    {
        throw new System.NotImplementedException();
    }
}