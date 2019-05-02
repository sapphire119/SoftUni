public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        var diffrence = this.EnergyStored - energyNeeded;
        if (diffrence < 0)
        {
            return false;
        }
        else
        {
            this.EnergyStored = diffrence;
        }

        return true;
    }
}