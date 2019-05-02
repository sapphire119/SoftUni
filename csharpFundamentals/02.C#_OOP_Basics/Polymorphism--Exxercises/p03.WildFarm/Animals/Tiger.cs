using System;

public class Tiger : Feline
{
    public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
        : base(name, weight, foodEaten, livingRegion, breed)
    {
    }

    public override void EatFood(string[] foodTokens)
    {
        if (ValidateFood(foodTokens))
        {
            var foodType = foodTokens[0];
            var foodQuantity = int.Parse(foodTokens[1]);
            if (foodType == FoodType.Meat.ToString() /*"meat"*/)
            {
                this.FoodEaten += foodQuantity;
                this.Weight += foodQuantity;
            }
            else
            {
                throw new ArgumentException(string.Format(FoodError, this.GetType().Name, foodType));
            } 
        }
    }

    public override string ProduceSound()
    {
        return $"ROAR!!!";
    }
}