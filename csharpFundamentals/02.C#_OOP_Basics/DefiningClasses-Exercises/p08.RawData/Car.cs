﻿public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car()
    {
        this.Tires = new Tire[4];
    }

    public Car(string model, Engine engine, Cargo cargo)
        :this()
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
    }

    public Tire[] Tires
    {
        get
        {
            return this.tires;
        }
        set
        {
            this.tires = value;
        }
    }


    public Cargo Cargo
    {
        get
        {
            return this.cargo;
        }
        set
        {
            this.cargo = value;
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
        return $"{this.Model}";
    }
}

