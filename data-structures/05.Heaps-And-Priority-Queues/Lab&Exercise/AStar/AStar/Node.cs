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

    public int CompareTo(Node other)
    {
        return this.Fcost.CompareTo(other.Fcost);
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
