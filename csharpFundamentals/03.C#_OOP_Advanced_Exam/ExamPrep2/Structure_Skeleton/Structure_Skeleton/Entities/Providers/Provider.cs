public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; private set; }

    public double EnergyOutput { get; protected set; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        throw new System.NotImplementedException();
    }

    public double Produce()
    {
        throw new System.NotImplementedException();
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}