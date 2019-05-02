using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class DraftManager
{
    private string workingMode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.providerFactory = new ProviderFactory();
        this.harvesterFactory = new HarvesterFactory();
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.workingMode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = harvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = providerFactory.CreateProvider(arguments);
            providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        var currentEnergyProvided = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += currentEnergyProvided;

        var dailyOreYield = 0.0;
        switch (this.workingMode)
        {
            case "Full": dailyOreYield = HarvestOre(1.0, 1.0); break;
            case "Half": dailyOreYield = HarvestOre(0.6, 0.5); break;
            case "Energy": break;
        }

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"A day has passed.")
            .AppendLine($"Energy Provided: {currentEnergyProvided}")
            .AppendLine($"Plumbus Ore Mined: {dailyOreYield}");

        var result = sb.ToString().TrimEnd();

        return result;
    }

    private double HarvestOre(double energyModeIndex, double oreIndex)
    {
        var energyRequirement = this.harvesters.Sum(h => h.EnergyRequirement) * energyModeIndex;

        var oreMined = 0.0;
        if (energyRequirement <= this.totalStoredEnergy)
        {
            this.totalStoredEnergy -= energyRequirement;

            double dayOreYield = this.harvesters.Sum(h => h.OreOutput) * oreIndex;
            oreMined += dayOreYield;

            this.totalMinedOre += oreMined;
        }

        return oreMined;
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];
        this.workingMode = mode;
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        Unit unit = (Unit)this.harvesters.Find(h => h.Id == id) ?? this.providers.Find(p => p.Id == id);
        if (unit != null)
            return unit.ToString();
        else
            return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}