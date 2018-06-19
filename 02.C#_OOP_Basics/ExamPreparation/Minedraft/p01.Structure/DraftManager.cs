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

    private ModeType WorkingMode { get; set; } = ModeType.Full;

    public string RegisterHarvester(List<string> arguments)
    {
        var isItValidType = Enum.TryParse(arguments[0], out HarvesterType type);
        if (!isItValidType)
        {
            return string.Format(Messages.UnsuccessfulHarvesterRegistrer, arguments[0]);
        }

        var id = arguments[1];

        var existingHarvester = this.harvesters.Find(h => h.Id == id);
        if (existingHarvester != null)
        {
            return string.Format(Messages.UnsuccessfulHarvesterRegistrer, id);
        }

        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        Harvester harvester = null;
        switch (type)
        {
            case HarvesterType.Sonic:
                var sonicFactor = int.Parse(arguments[4]);
                harvester = new Sonic(id, energyRequirement, oreOutput, sonicFactor);
                break;
            case HarvesterType.Hammer:
                harvester = new Hammer(id, energyRequirement, oreOutput);
                break;
        }

        this.harvesters.Add(harvester);

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        var isItValidType = Enum.TryParse(arguments[0], out ProviderType type);
        if (!isItValidType)
        {
            return string.Format(Messages.UnsuccessfulProviderRegister, arguments[0]);
        }

        var id = arguments[1];
        var existingProvider = this.providers.Find(p => p.Id == id);
        if (existingProvider != null)
        {
            return string.Format(Messages.UnsuccessfulProviderRegister, id);
        }

        Provider provider = null;
        var energyOutput = double.Parse(arguments[2]);
        switch (type)
        {
            case ProviderType.Solar:
                provider = new Solar(id, energyOutput);
                break;
            case ProviderType.Pressure:
                provider = new Pressure(id, energyOutput);
                break;
        }

        this.providers.Add(provider);

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        var currentProducedEnergy = this.providers.Sum(p => p.EnergyOutput);
        this.TotalStoredEnergy += currentProducedEnergy;

        var currentOreYield = 0.0;
        switch (this.WorkingMode)
        {
            case ModeType.Full:
                currentOreYield = CalculateWorkOutput(this.TotalStoredEnergy, this.harvesters, 1, 1);
                break;
            case ModeType.Half:
                currentOreYield = CalculateWorkOutput(this.TotalStoredEnergy, this.harvesters, 0.60, 0.50);
                break;
            case ModeType.Energy:
                break;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"A day has passed.")
            .AppendLine($"Energy Provided: {currentProducedEnergy}")
            .AppendLine($"Plumbus Ore Mined: {currentOreYield}");

        var result = sb.ToString().TrimEnd();

        return result;
    }



    public string Mode(List<string> arguments)
    {
        var type = Enum.Parse<ModeType>(arguments[0]);

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

        return $"Successfully changed working mode to {this.WorkingMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var existingHarvester = this.harvesters.Find(h => h.Id == id);
        if (existingHarvester != null)
        {
            return existingHarvester.ToString();
        }

        var existingProvider = this.providers.Find(p => p.Id == id);
        if (existingProvider != null)
        {
            return existingProvider.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"System Shutdown")
            .AppendLine($"Total Energy Stored: {this.TotalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {this.TotalMinedOre}");

        var result = sb.ToString().TrimEnd();

        return result;
    }

    private double CalculateWorkOutput(double totalStoredEnergy, List<Harvester> harvesters, double energyIndex, double oreIndex)
    {
        double oreMinedForTheDay = 0.0;
        var energyRequirement = this.harvesters.Sum(h => h.EnergyRequirement) * energyIndex;
        if (energyRequirement <= this.TotalStoredEnergy)
        {
            foreach (var harvester in this.harvesters)
            {
                this.TotalStoredEnergy -= harvester.EnergyRequirement * energyIndex;
                oreMinedForTheDay += (harvester.OreOutput * oreIndex);
            }

            this.TotalMinedOre += oreMinedForTheDay;
        }

        return oreMinedForTheDay;
    }
}