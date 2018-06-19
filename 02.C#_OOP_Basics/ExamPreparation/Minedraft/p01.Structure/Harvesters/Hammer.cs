public class Hammer : Harvester
{
    public Hammer(string id, double energyRequirement, double oreOutput) 
        : base(id, energyRequirement, oreOutput)
    {
        this.OreOutput = (this.OreOutput * 3.0);
        this.EnergyRequirement = (this.EnergyRequirement * 2.0);
    }
}