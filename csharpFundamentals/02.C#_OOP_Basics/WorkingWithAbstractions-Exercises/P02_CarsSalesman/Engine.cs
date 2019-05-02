using System;
using System.Text;

public class Engine
{
    private string model;
    private string power;
    private string displacement;
    private string efficiency;

    public Engine() { }

    public Engine(string model, string power)
        : this()
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = "n/a";
        this.Efficiency = "n/a";
    }

    public Engine(string model, string power, string displacement, string efficiency)
        : this(model, power)
    {
        this.Displacement = displacement;
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

    public string Displacement
    {
        get
        {
            return this.displacement;
        }
        set
        {
            this.displacement = value;
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
               $"   Displacement: {this.Displacement}" + Environment.NewLine +
               $"   Efficiency: {this.Efficiency}";
    }
}