public class SolarProvider : Provider
{
    private const int SolarProviderAddedDurability = 500;

    public SolarProvider(int id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.Durability += SolarProviderAddedDurability;
    }
}