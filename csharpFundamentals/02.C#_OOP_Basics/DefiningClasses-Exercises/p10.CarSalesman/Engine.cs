using System;

public class Engine
{
    private string model;
    private string power;
    private string displacements; //optional
    private string efficiency;  //optional

    public Engine() { }

    public Engine(string model, string power)
        : this()
    {
        this.Model = model;
        this.Power = power;
        this.Displacements = "n/a";
        this.Efficiency = "n/a";
    }

    public Engine(string model, string power, string displacements, string efficiency)
        : this(model, power)
    {
        this.Displacements = displacements;
        this.Efficiency = efficiency;
    }

    public string Efficiency
    {
        get
        {
            return this.efficiency;
        }
        set
        {
            this.efficiency = value;
        }
    }


    public string Displacements
    {
        get
        {
            return this.displacements;
        }
        set
        {
            this.displacements = value;
        }
    }



    public string Power
    {
        get
        {
            return this.power;
        }
        set
        {
            this.power = value;
        }
    }


    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            this.model = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Model}:" + Environment.NewLine +
               $"   Power: {this.Power}" + Environment.NewLine +
               $"   Displacement: {this.Displacements}" + Environment.NewLine +
               $"   Efficiency: {this.Efficiency}";
    }
}