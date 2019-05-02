using System.Linq;

public class Rectangle
{
    private Point topLeftPoint;
    private Point bottomRightPoint;

    public Rectangle() { }

    public Rectangle(Point topLeftPoint, Point bottomRightPoint)
        : this()
    {
        this.TopLeftPoint = topLeftPoint;
        this.BottomRightPoint = bottomRightPoint;
    }

    public Rectangle(string coordsLine)
    {
        var coordinates = coordsLine.Split().Select(decimal.Parse).ToArray();

        this.TopLeftPoint = new Point(coordinates[0], coordinates[1]);
        this.BottomRightPoint = new Point(coordinates[2], coordinates[3]);
    }

    public Point BottomRightPoint
    {
        get
        {
            return this.bottomRightPoint;
        }
        set
        {
            this.bottomRightPoint = value;
        }
    }

    public Point TopLeftPoint
    {
        get
        {
            return this.topLeftPoint;
        }
        set
        {
            this.topLeftPoint = value;
        }
    }

    public bool Contains(Point point)
    {
        var isPointInside = true;
        bool checkX = this.TopLeftPoint.X <= point.X && point.X <= this.BottomRightPoint.X;
        bool checkY = this.TopLeftPoint.Y <= point.Y && point.Y <= this.BottomRightPoint.Y;

        if (!checkX || !checkY)
        {
            isPointInside = false;
        }

        return isPointInside;
    }
}