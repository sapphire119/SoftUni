using System;

public class Node : IComparable<Node>
{
    public Node(int row, int col)
    {
        this.Row = row;
        this.Column = col;
    }

    public int Row { get; set; }

    public int Column { get; set; }

    public int Fcost { get; set; }

    public int Hcost { get; set; }

    public int Gcost { get; set; }

    public Node PreviousNode { get; set; }

    public int CompareTo(Node other)
    {
        var comparison = this.Fcost.CompareTo(other.Fcost);

        if (comparison == 0)
        {
            return this.Hcost.CompareTo(other.Hcost);
        }

        return comparison;
    }

    public override bool Equals(object obj)
    {
        var other = (Node)obj;
        return this.Column == other.Column && this.Row == other.Row;
    }

    public override int GetHashCode()
    {
        var hash = 17;
        hash = 31 * hash + this.Row.GetHashCode();
        hash = 31 * hash + this.Column.GetHashCode();
        return hash;
    }

    public override string ToString()
    {
        return this.Row + " " + this.Column;
    }
}
