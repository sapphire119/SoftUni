public class Pressure : Provider
{
    public Pressure(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput = (energyOutput * 1.5);
    }
}