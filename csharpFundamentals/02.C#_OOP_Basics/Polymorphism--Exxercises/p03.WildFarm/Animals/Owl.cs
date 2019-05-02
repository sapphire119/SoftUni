using System;

public class Owl : Bird
{
    public Owl(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten, wingSize)
    {
    }

    public override void EatFood(string[] foodTokens)
    {
        if (ValidateFood(foodTokens))
        {
            if (foodTokens[0] == FoodType.Meat.ToString())
            {
                var foodQuantity = int.Parse(foodTokens[1]);
                this.FoodEaten += foodQuantity;
                this.Weight += (foodQuantity * 0.25);
            }
            else
            {
                throw new ArgumentException(string.Format(FoodError, this.GetType().Name, foodTokens[0]));
            }
        }
    }

    public override string ProduceSound()
    {
        return $"Hoot Hoot";
    }
}