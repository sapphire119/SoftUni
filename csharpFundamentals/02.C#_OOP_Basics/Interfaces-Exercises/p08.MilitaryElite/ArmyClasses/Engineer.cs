using System.Text;
using System.Collections.Generic;
using System;

public class Engineer : Private, IEngineer
{
    private List<IRepairable> repairs;

    public Engineer(int id, string firstName, string lastName, double salary, CorpType corp)
        : base(id, firstName, lastName, salary)
    {
        this.Corp = corp;
        this.repairs = new List<IRepairable>();
    }

    public CorpType Corp { get; private set; }

    public IReadOnlyCollection<IRepairable> Repairs => this.repairs;

    public void AddRepair(IRepairable repair)
    {
        this.repairs.Add(repair);
    }

    private string MakeRepairs()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var repair in this.Repairs)
        {
            sb.AppendLine($"    Part Name: {repair.PartName} Hours Worked: {repair.PartHoursWorker}");
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corp.ToString()}")
            .AppendLine($"Repairs:")
            .AppendLine($"{MakeRepairs()}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}