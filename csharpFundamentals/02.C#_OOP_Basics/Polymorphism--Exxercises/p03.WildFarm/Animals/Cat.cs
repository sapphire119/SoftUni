using System;

public class Cat : Feline
{
    public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
        : base(name, weight, foodEaten, livingRegion, breed)
    {
    }

    public override void EatFood(string[] foodTokens)
    {
        if (ValidateFood(foodTokens))
        {
            if (foodTokens[0] == FoodType.Vegetable.ToString() /*"vegetables" */|| foodTokens[0] == FoodType.Meat.ToString()/* "meat"*/)
            {
                var foodQuantity = int.Parse(foodTokens[1]);
                this.FoodEaten += foodQuantity;
                this.Weight += (foodQuantity * 0.30);
            }
            else
            {
                throw new ArgumentException(string.Format(FoodError, this.GetType().Name, foodTokens[0]));
            } 
        }
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}