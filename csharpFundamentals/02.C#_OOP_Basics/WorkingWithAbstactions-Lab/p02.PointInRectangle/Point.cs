using System;
using System.Linq;

public class Point
{
    private decimal x;
    private decimal y;

    public Point() { }

    public Point(decimal x, decimal y)
        : this()
    {
        this.X = x;
        this.Y = y;
    }

    public Point(Func<string> readPoint)
    {
        var currentPoint = readPoint().Split().Select(decimal.Parse).ToArray();
        this.X = currentPoint[0];
        this.Y = currentPoint[1];
    }

    public decimal Y
    {
        get
        {
            return this.y;
        }
        set
        {
            this.y = value;
        }
    }

    public decimal X
    {
        get
        {
            return this.x;
        }
        set
        {
            this.x = value;
        }
    }

}