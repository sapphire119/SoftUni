public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double energyRequirement, double oreOutput) 
        : base(id, energyRequirement, oreOutput)
    {
        this.OreOutput += (this.OreOutput * 2.0);
        this.EnergyRequirement += (this.EnergyRequirement);
    }
}