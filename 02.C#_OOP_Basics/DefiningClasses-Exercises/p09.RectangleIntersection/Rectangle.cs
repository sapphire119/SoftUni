public class Rectangle
{
    private string id;
    private decimal width;
    private decimal height;
    private TopLeftCorner topLeftCorner;

    public Rectangle() { }

    public Rectangle(string id, decimal width, decimal height)
        : this()
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
    }

    public TopLeftCorner TopLeftCorner
    {
        get
        {
            return this.topLeftCorner;
        }
        set
        {
            this.topLeftCorner = value;
        }
    }

    public decimal Height
    {
        get
        {
            return this.height;
        }
        set
        {
            this.height = value;
        }
    }

    public decimal Width
    {
        get
        {
            return this.width;
        }
        set
        {
            this.width = value;
        }
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    public bool FindIntersection(Rectangle secondRectangle)
    {
        bool doTheyIntersect = true;

        bool isItOutOfBoundsFirstTriangleTop = (this.TopLeftCorner.X + this.Width) < secondRectangle.TopLeftCorner.X;
        bool isItOutOfBoundsSecondTriangleTop = (secondRectangle.TopLeftCorner.X + secondRectangle.Width) < this.TopLeftCorner.X;
        bool isItOutOfBoundsFirstTriangleVertical = (this.TopLeftCorner.Y + this.Height) < secondRectangle.TopLeftCorner.Y;
        bool isItOutOfBoundsSecondTriangleVertical = (secondRectangle.TopLeftCorner.Y + secondRectangle.Height) < this.TopLeftCorner.Y;

        if (isItOutOfBoundsFirstTriangleTop || 
            isItOutOfBoundsSecondTriangleTop || 
            isItOutOfBoundsFirstTriangleVertical || 
            isItOutOfBoundsSecondTriangleVertical)
        {
            doTheyIntersect = false;
        }

        return doTheyIntersect;
    }
}

