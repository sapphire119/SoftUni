using System;
using System.Linq;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car() { }

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = "n/a";
        this.Color = "n/a";
    }

    public Car(string model, Engine engine, string weight, string color)
        :this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }


    public string Color
    {
        get
        {
            return this.color;
        }
        set
        {
            this.color = value;
        }
    }

    public string Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            this.weight = value;
        }
    }

    public Engine Engine
    {
        get
        {
            return this.engine;
        }
        set
        {
            this.engine = value;
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
                $"  {this.Engine}" + Environment.NewLine +
                $"  Weight: {this.Weight}" + Environment.NewLine +
                $"  Color: {this.Color}";
    }
}