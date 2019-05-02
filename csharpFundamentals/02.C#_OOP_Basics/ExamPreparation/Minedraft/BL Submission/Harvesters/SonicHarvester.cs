public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double energyRequirement, double oreOutput, int sonicFactor) 
        : base(id, energyRequirement, oreOutput)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= (double) this.SonicFactor;
    }

    public int SonicFactor
    {
        get
        {
            return this.sonicFactor;
        }
        set
        {
            ValidateOutputEnergy(value, nameof(this.SonicFactor));
            this.sonicFactor = value;
        }
    }
}