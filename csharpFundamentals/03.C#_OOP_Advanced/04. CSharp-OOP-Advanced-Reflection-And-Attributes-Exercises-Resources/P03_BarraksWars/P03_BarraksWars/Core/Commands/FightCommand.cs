using System;
using _03BarracksFactory.Contracts;

public class FightCommand : Command
{
    public FightCommand(string[] data) 
        : base(data)
    {
    }

    public override string Execute()
    {
        Environment.Exit(0);
        return string.Empty;
    }
}