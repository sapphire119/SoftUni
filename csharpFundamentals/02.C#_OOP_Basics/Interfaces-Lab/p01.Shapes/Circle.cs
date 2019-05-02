using System;

public class Circle : IDrawable
{
    private double radius;

    public Circle() { }

    public Circle(int radius)
        : this()
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get
        {
            return this.radius;
        }
        private set
        {
            this.radius = value;
        }
    }

    public void Draw()
    {
        double radiusIn = this.Radius - 0.4;
        double radiusOut = this.Radius + 0.4;

        for (double y = this.Radius; y >= -this.Radius; --y) 
        {
            for (double x = -this.Radius; x < radiusOut; x += 0.5)
            {
                double value = Math.Pow(x, 2) + Math.Pow(y, 2);

                if (value >= Math.Pow(radiusIn, 2) && value <= Math.Pow(radiusOut, 2))
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}