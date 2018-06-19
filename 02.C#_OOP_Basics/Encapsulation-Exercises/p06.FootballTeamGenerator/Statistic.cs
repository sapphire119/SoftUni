using System;

public class Statistic
{
    //endurance, sprint, dribble, passing and shooting.
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Statistic() { }

    public Statistic(int endurance, int sprint, int dribble, int passing, int shooting)
        : this()
    {
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public int Shooting
    {
        get
        {
            return this.shooting;
        }
        set
        {
            IsStatOutOfBound(value, nameof(Shooting));
            this.shooting = value;
        }
    }

    public int Passing
    {
        get
        {
            return this.passing;
        }
        set
        {
            IsStatOutOfBound(value, nameof(Passing));
            this.passing = value;
        }
    }

    public int Dribble
    {
        get
        {
            return this.dribble;
        }
        set
        {
            IsStatOutOfBound(value, nameof(Dribble));
            this.dribble = value;
        }
    }

    public int Sprint
    {
        get
        {
            return this.sprint;
        }
        set
        {
            IsStatOutOfBound(value, nameof(Sprint));
            this.sprint = value;
        }
    }

    public int Endurance
    {
        get
        {
            return this.endurance;
        }
        set
        {
            IsStatOutOfBound(value, nameof(Endurance));
            this.endurance = value;
        }
    }

    private void IsStatOutOfBound(int statValue, string statName)
    {
        if (!(0 <= statValue && statValue <= 100)) 
        {
            throw new ArgumentException($"{statName} should be between 0 and 100.");
        }
    }
}
