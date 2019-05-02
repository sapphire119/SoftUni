using System.Text;
using System.Collections.Generic;
using System;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private HashSet<IPrivate> privates;

    public LeutenantGeneral(int id, string firstName, string lastName, double salary) 
        : base(id, firstName, lastName, salary)
    {
        this.privates = new HashSet<IPrivate>();
    }

    //public HashSet<IPrivate> Privates { get; private set; } = new HashSet<IPrivate>();

    public IReadOnlyCollection<IPrivate> Privates => this.privates;

    public void AddPrivate(IPrivate soldier)
    {
        this.privates.Add(soldier);
    }

    private string PrintPrivates()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var @private in this.Privates)
        {
            sb.AppendLine($"    {@private}");
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString())
            .AppendLine("Privates:")
            .AppendLine($"{PrintPrivates()}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}