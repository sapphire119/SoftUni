using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Parent> parents;
    private List<Child> children;
    private List<Pokemon> pokemons;

    public Person()
    {
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
        this.Pokemons = new List<Pokemon>();
    }

    public Person(string name)
        :this()
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public List<Pokemon> Pokemons
    {
        get
        {
            return this.pokemons;
        }
        set
        {
            this.pokemons = value;
        }
    }

    public List<Child> Children
    {
        get
        {
            return this.children;
        }
        set
        {
            this.children = value;
        }
    }

    public List<Parent> Parents
    {
        get
        {
            return this.parents;
        }
        set
        {
            this.parents = value;
        }
    }

    public Car Car
    {
        get
        {
            return this.car;
        }
        set
        {
            this.car = value;
        }
    }

    public Company Company
    {
        get
        {
            return this.company;
        }
        set
        {
            this.company = value;
        }
    }

    public override string ToString()
    {
        var printCompany = this.Company != null ? (this.Company + Environment.NewLine) : null;

        var printCar = this.Car != null ? (this.Car + Environment.NewLine) : null;

        var printPokemons = this.Pokemons.Count != 0 ?
            (string.Join(Environment.NewLine, this.Pokemons) + Environment.NewLine) : null;

        var printParents = this.Parents.Count != 0 ?
            (string.Join(Environment.NewLine, this.Parents) + Environment.NewLine) : null;

        var printChildren = this.Children.Count != 0 ?
            (Environment.NewLine + string.Join(Environment.NewLine, this.Children)) : null;

        return $"{this.Name}" + Environment.NewLine +
                $"Company:" + Environment.NewLine +
               $"{printCompany}" +
               $"Car:" + Environment.NewLine +
               $"{printCar}" +
               $"Pokemon:" + Environment.NewLine +
               $"{printPokemons}" +
               $"Parents:" + Environment.NewLine +
               $"{printParents}" +
               $"Children:" +
               $"{printChildren}";
    }
}