using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class DraftManager
{
    private List<Harvester> harvesters = new List<Harvester>();
    private List<Provider> providers = new List<Provider>();

    private double TotalStoredEnergy { get; set; }

    private double TotalMinedOre { get; set; }

    public IReadOnlyCollection<Harvester> Harvesters => this.harvesters;

    public IReadOnlyCollection<Provider> Providers => providers;

    private ModeType WorkingMode { get; set; } = ModeType.Full;

    public string RegisterHarvester(List<string> arguments)
    {
        var isItValidType = Enum.TryParse(arguments[0], out HarvesterType type);
        if (!isItValidType)
        {
            return string.Empty;
        }

        var id = arguments[1];

        var existingHarvester = this.harvesters.Find(h => h.Id == id);
        if (existingHarvester == null)
        {
            var oreOutput = double.Parse(arguments[2]);
            var energyRequirement = double.Parse(arguments[3]);

            Harvester harvester = null;
            switch (type)
            {
                case HarvesterType.Sonic:
                    var sonicFactor = int.Parse(arguments[4]);
                    harvester = new SonicHarvester(id, energyRequirement, oreOutput, sonicFactor);
                    break;
                case HarvesterType.Hammer:
                    harvester = new HammerHarvester(id, energyRequirement, oreOutput);
                    break;
            }

            this.harvesters.Add(harvester);

            return string.Empty;
        }

        return null;
    }

    public string RegisterProvider(List<string> arguments)
    {
        var isItValidType = Enum.TryParse(arguments[0], out ProviderType type);
        if (!isItValidType)
        {
            return string.Empty;
        }

        var id = arguments[1];
        var existingProvider = this.providers.Find(p => p.Id == id);
        if (existingProvider == null)
        {
            Provider provider = null;
            var energyOutput = double.Parse(arguments[2]);
            switch (type)
            {
                case ProviderType.Solar:
                    provider = new SolarProvider(id, energyOutput);
                    break;
                case ProviderType.Pressure:
                    provider = new PressureProvider(id, energyOutput);
                    break;
            }

            this.providers.Add(provider);

            return string.Empty;
        }

        return null;
    }

    public string Day()
    {
        this.TotalStoredEnergy += this.providers.Sum(p => p.EnergyOutput);

        switch (this.WorkingMode)
        {
            case ModeType.Full:
                CalculateFullWorkOutput(this.TotalStoredEnergy, this.harvesters);
                break;
            case ModeType.Half:
                CalculateHalfWorkOutput(this.TotalStoredEnergy, this.harvesters);
                break;
            case ModeType.Energy:
                break;
        }

        return string.Empty;
    }

   

    public string Mode(List<string> arguments)
    {
        var isItValidType = Enum.TryParse(arguments[0], out ModeType type);
        if (!isItValidType)
        {
            return string.Empty;
        }

        switch (type)
        {
            case ModeType.Full:
                this.WorkingMode = ModeType.Full;
                break;
            case ModeType.Half:
                this.WorkingMode = ModeType.Half;
                break;
            case ModeType.Energy:
                this.WorkingMode = ModeType.Energy;
                break;
        }

        return string.Empty;
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var existingHarvester = this.harvesters.Find(h => h.Id == id);
        if (existingHarvester != null)
        {
            return string.Empty;
        }

        var existingProvider = this.providers.Find(p => p.Id == id);
        if (existingProvider != null)
        {
            return string.Empty;
        }

        return string.Empty;
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.TotalStoredEnergy}")
            .AppendLine($"{this.TotalMinedOre}");

        var result = sb.ToString().TrimEnd();

        return result;
    }

    private void CalculateFullWorkOutput(double totalStoredEnergy, List<Harvester> harvesters)
    {
        var energyRequirement = this.harvesters.Sum(h => h.EnergyRequirement);
        if (energyRequirement <= this.TotalStoredEnergy)
        {
            foreach (var harvester in this.harvesters)
            {
                this.TotalStoredEnergy -= harvester.EnergyRequirement;
                this.TotalMinedOre += harvester.OreOutput;
            }
        }
    }

    private void CalculateHalfWorkOutput(double totalStoredEnergy, List<Harvester> harvesters)
    {
        var energyRequirement = this.harvesters.Sum(h => h.EnergyRequirement) * 0.60;
        if (energyRequirement <= this.TotalStoredEnergy)
        {
            foreach (var harvester in this.harvesters)
            {
                this.TotalStoredEnergy -= harvester.EnergyRequirement * 0.60;
                this.TotalMinedOre += (harvester.OreOutput * 0.50);
            }
        }
    }
}