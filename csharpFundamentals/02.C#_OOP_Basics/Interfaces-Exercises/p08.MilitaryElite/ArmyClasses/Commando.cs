using System.Text;
using System.Collections.Generic;
using System;

public class Commando : Private, ICommando
{
    private List<IMission> missions;

    public Commando(int id, string firstName, string lastName, double salary, CorpType corps) 
        : base(id, firstName, lastName, salary)
    {
        this.Corp = corps;
        this.missions = new List<IMission>();
    }

    public CorpType Corp { get; private set; }

    public IReadOnlyCollection<IMission> Missions => this.missions;

    public void AddMission(IMission mission)
    {
        this.missions.Add(mission);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corp.ToString()}")
            .AppendLine($"Missions:")
            .AppendLine($"{PrintMissions()}");

        var result = sb.ToString().TrimEnd();

        return result;
    }

    private string PrintMissions()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var mission in this.Missions)
        {
            sb.AppendLine($"    Code Name: {mission.MissionCodeName} State: {mission.MissionState}");
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }
}