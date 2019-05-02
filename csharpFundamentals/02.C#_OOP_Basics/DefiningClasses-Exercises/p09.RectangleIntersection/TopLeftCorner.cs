public class TopLeftCorner
{
    private decimal x;
    private decimal y;

    public TopLeftCorner() { }

    public TopLeftCorner(decimal x, decimal y)
        : this()
    {
        this.X = x;
        this.Y = y;
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

