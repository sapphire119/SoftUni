using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten, livingRegion)
    {
    }

    public override void EatFood(string[] foodTokens)
    {
        if (ValidateFood(foodTokens))
        {
            if (foodTokens[0] == FoodType.Vegetable.ToString() /*"vegatble"*/ || foodTokens[0] == FoodType.Fruit.ToString()  /*"fruit"*/)
            {
                var foodQuantity = int.Parse(foodTokens[1]);
                this.FoodEaten += foodQuantity;
                this.Weight += (foodQuantity * 0.10);
            }
            else
            {
                throw new ArgumentException(string.Format(FoodError, this.GetType().Name, foodTokens[0]));
            } 
        }
    }

    public override string ProduceSound()
    {
        return $"Squeak";
    }
}