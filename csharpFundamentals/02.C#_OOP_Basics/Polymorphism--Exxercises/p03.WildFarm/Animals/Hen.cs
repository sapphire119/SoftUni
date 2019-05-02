using System;

public class Hen : Bird
{
    public Hen(string name, double weight, int foodEaten, double wingSize) 
        : base(name, weight, foodEaten, wingSize)
    {
    }

    public override void EatFood(string[] foodtokens)
    {
        if (ValidateFood(foodtokens))
        {
            var foodQuantity = int.Parse(foodtokens[1]);
            this.FoodEaten += foodQuantity;
            this.Weight += (foodQuantity * 0.35);
        }
    }

    public override string ProduceSound()
    {
        return $"Cluck";
    }
}