using System;

public abstract class Animal : IAnimal
{
    protected const string FoodError = "{0} does not eat {1}!";

    public Animal(string name, double weight, int foodEaten)
    {
       this.Name = name;
       this.Weight = weight;
       this.FoodEaten = foodEaten;
    }  

    public string Name { get; private set; }

    public double Weight { get; protected set; }

    public int FoodEaten { get; protected set; }

    public abstract string ProduceSound();

    public abstract void EatFood(string[] foodTokens);

    public bool ValidateFood(string[] foodtokens)
    {
        if (foodtokens.Length != 2)
        {
            return false;
        }

        var isItFood = Enum.TryParse(foodtokens[0], out FoodType food);
        if (!isItFood)
        {
            throw new ArgumentException(string.Format(FoodError, this.GetType().Name, foodtokens[0]));
        }

        var isItValidQuantity = int.TryParse(foodtokens[1], out int foodQuantity);
        if (!isItValidQuantity)
        {
            return false;
        }


        return true;
    }
}