﻿public abstract class Bird : Animal, IBird
{
    public Bird(string name, double weight, int foodEaten, double wingSize) 
        : base(name, weight, foodEaten)
    {
        this.WingSize = wingSize;
    }
    
    public double WingSize { get; private set; }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}