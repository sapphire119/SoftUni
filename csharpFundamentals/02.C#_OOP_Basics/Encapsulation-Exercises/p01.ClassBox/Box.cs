public class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public Box() { }

    public Box(decimal length, decimal width, decimal height)
        : this()
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
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

    public decimal Length
    {
        get
        {
            return this.length;
        }
        set
        {
            this.length = value;
        }
    }

    public string CalculateSurfaceArea()
    {
        var surfaceArea = 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);
        return $"Surface Area - {surfaceArea:F2}";
    }

    public string CalculateLateralSurface()
    {
        var lateralArea = 2 * (this.Length * this.Height + this.Width * this.Height);
        return $"Lateral Surface Area - {lateralArea:F2}";
    }

    public string CalculateVolume()
    {
        var volumeOfBox = this.Length * this.Width * this.Height;
        return $"Volume - {volumeOfBox:F2}";
    }
}