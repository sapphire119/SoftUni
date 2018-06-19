using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private IList<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory harvesterFactory;

    private string currentMode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;

        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = new HarvesterFactory();

        this.currentMode = "Full";
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => (IReadOnlyCollection<IEntity>)this.harvesters;

    public string ChangeMode(string mode)
    {
        this.currentMode = mode;

        return string.Format(Constants.SuccessfullyChangedMode, mode);
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.currentMode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.currentMode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.currentMode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {   
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.OreOutput;
            }
        }

        //take the mode in mind
        if (this.currentMode == "Energy")
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.currentMode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }
        

        this.OreProduced += minedOres;

        return null;
    }

    public string Register(IList<string> args)
    {
        throw new System.NotImplementedException();
    }
}