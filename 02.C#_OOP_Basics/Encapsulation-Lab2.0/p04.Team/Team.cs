using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;
    
    public Team()
    {
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public Team(string name)
        : this()
    {
        this.Name = name;
    }

    public ReadOnlyCollection<Person> FirstTeam
    {
        get
        {
            return new ReadOnlyCollection<Person>(this.firstTeam);
        }
    }

    public ReadOnlyCollection<Person> ReserveTeam
    {
        get
        {
            return new ReadOnlyCollection<Person>(this.reserveTeam);
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

    public void AddPlayer(Person player)
    {
        if (player.Age < 40)
            this.firstTeam.Add(player);
        else
            this.reserveTeam.Add(player);
    }

    public override string ToString()
    {
        return $"First team has {this.firstTeam.Count} players." + Environment.NewLine +
               $"Reserve team has {this.reserveTeam.Count} players.";
    }
}