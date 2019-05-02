using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var shapes = new List<Shape>();

        var circle = new Circle(4.65);
        var rectangle = new Rectangle(4.6, 5.3);

        shapes.Add(circle);
        shapes.Add(rectangle);

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}

public abstract class Shape
{
    public abstract double CalculatePerimeter();

    public abstract double CalculateArea();

    public virtual string Draw()
    {
        return "Drawing ";
    }
}


public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
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
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(this.Radius)}", "Radius must be non-zero and posititve!");
            }

            this.radius = value;
        }
    }

    public override double CalculateArea()
    {
        var area = Math.PI * this.Radius * this.Radius;
        return area;
    }

    public override double CalculatePerimeter()
    {
        var perimeter = 2 * Math.PI * this.Radius;
        return perimeter;
    }

    public override string Draw()
    {
        return base.Draw() + $"{this.GetType().Name}";
    }
}

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(this.Height)}", "Height must be non-zero and posititve!");
            }

            this.height = value;
        }
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(this.Width)}", "Width must be non-zero and posititve!");
            }

            this.width = value;
        }
    }

    public override double CalculateArea()
    {
        var area = this.Height * this.Width;
        return area;
    }

    public override double CalculatePerimeter()
    {
        var perimeter = 2 * (this.Height + this.Width);
        return perimeter;
    }

    public override string Draw()
    {
        return base.Draw() + $"{this.GetType().Name}";
    }
}

