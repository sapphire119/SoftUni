using System;
using System.Linq;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings = new List<Topping>();

    public Pizza() { }

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
    }

    public Dough Dough
    {
        get
        {
            return this.dough;
        }
        set
        {
            this.dough = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public IReadOnlyCollection<Topping> Toppings => this.toppings;

    public long TotalToppings => this.toppings.Count;

    public decimal PizzaCalories => this.CalculateCalories();

    public void AddTopping(Topping topping)
    {
        if (this.TotalToppings > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }

    private decimal CalculateCalories()
    {
        var totalCaloriesInPizza = this.Dough.CaloriesInDough + this.toppings.Sum(t => t.CaloriesInTopping);
        
        return totalCaloriesInPizza;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.PizzaCalories:F2} Calories.";
    }

}