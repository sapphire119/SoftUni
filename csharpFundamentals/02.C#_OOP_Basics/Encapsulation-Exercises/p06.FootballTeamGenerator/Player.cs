using System;
using System.Linq;

public class Player
{
    private string name;
    private Statistic stats;

    public Player() { }

    public Player(string name, Statistic stats)
        : this()
    {
        this.Name = name;
        this.Stats = stats;
    }

    public Statistic Stats
    {
        get
        {
            return this.stats;
        }
        private set
        {
            this.stats = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public decimal PlayerAverageStats => this.GetAverageStats();

    private decimal GetAverageStats()
    {
        var averageStats = 
            (this.Stats.Dribble + this.Stats.Endurance + this.Stats.Passing + this.Stats.Shooting + this.Stats.Sprint) / 5.0M;

        return averageStats;
    }
}