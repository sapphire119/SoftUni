using System.Linq;
using System.Collections.Generic;
using System;

public class Team
{
    private string name;
    private List<Player> players = new List<Player>();

    public Team() { }

    public Team(string name)
        : this()
    {
        this.Name = name;
    }

    public IReadOnlyCollection<Player> Players => this.players;

    public decimal Rating
    {
        get
        {
            return this.CalculateRating();
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
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    private decimal CalculateRating()
    {
        var teamRating = this.Players.Count != 0 ? this.Players.Average(p => p.PlayerAverageStats) : 0M;
        return Math.Round(teamRating, 0);
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        var existingPlayer = this.players.Find(p => p.Name == playerName);
        if (existingPlayer == null)
        {
            throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
        }
        this.players.Remove(existingPlayer);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Rating}";
    }
}