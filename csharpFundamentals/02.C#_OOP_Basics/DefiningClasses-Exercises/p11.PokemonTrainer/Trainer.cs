using System.Collections.Generic;

public class Trainer
{
    private string name;
    private long numberOfBadges;
    private List<Pokemon> pokemons;

    public Trainer()
    {
        this.Pokemons = new List<Pokemon>();
    }

    public Trainer(string name)
        : this()
    {
        this.Name = name;
        this.NumberOfBadges = 0;
    }

    public Trainer(string name, long numberOfBadges)
        : this(name)
    {
        this.NumberOfBadges = numberOfBadges;
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

    public long NumberOfBadges
    {
        get
        {
            return this.numberOfBadges;
        }
        set
        {
            this.numberOfBadges = value;
        }
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

    public override string ToString()
    {
        return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
    }
}