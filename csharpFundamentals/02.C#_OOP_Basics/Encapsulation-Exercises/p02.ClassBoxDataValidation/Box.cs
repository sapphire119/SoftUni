using System;

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
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(this.Height)}" + Exceptions.boxSideExpcetion.Message);
            }
            this.height = value;
        }
    }

    public decimal Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(this.Width)}" + Exceptions.boxSideExpcetion.Message);
            }
            this.width = value;
        }
    }

    public decimal Length
    {
        get
        {
            return this.length;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(this.Length)}" + Exceptions.boxSideExpcetion.Message);
            }
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