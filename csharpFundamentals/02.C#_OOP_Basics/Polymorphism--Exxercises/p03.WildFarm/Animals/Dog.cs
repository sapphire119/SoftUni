using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten, livingRegion)
    {
    }

    public override void EatFood(string[] foodTokens)
    {
        if (ValidateFood(foodTokens))
        {
            if (foodTokens[0] == FoodType.Meat.ToString()/* "meat"*/)
            {
                var foodQuantity = int.Parse(foodTokens[1]);
                this.FoodEaten += foodQuantity;
                this.Weight += (foodQuantity * 0.40);
            }
            else
            {
                throw new ArgumentException(string.Format(FoodError, this.GetType().Name, foodTokens[0]));
            }
        }
    }

    public override string ProduceSound()
    {
        return $"Woof!";
    }
}