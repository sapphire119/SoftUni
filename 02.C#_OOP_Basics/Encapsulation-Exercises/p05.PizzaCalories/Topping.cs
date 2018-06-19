using System;

public class Topping
{
    private string toppingtype;
    private decimal weight;

    public Topping() { }

    public Topping(string toppingType, decimal weight)
        : this()
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    public decimal Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            if (!(1.0M <= value && value <= 50.0M))
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public string ToppingType
    {
        get
        {
            return this.toppingtype;
        }
        set
        {
            if (!ToppingtypeType.ToppingTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.toppingtype = value;
        }
    }

    public decimal CaloriesInTopping => this.CalculateCalories();

    private decimal CalculateCalories()
    {
        var calories = (2 * this.Weight) * ToppingtypeType.ToppingTypes[this.ToppingType.ToLower()];

        return calories;
    }
}