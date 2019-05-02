public class Sonic : Harvester
{
    private int sonicFactor;

    public Sonic(string id, double energyRequirement, double oreOutput, int sonicFactor) 
        : base(id, energyRequirement / sonicFactor, oreOutput)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement = (this.EnergyRequirement / (double)this.SonicFactor);
    }

    public int SonicFactor
    {
        get
        {
            return this.sonicFactor;
        }
        set
        {
            ValidateParam(value, nameof(this.SonicFactor));
            this.sonicFactor = value;
        }
    }
}