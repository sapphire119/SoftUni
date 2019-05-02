public abstract class Mammal : Animal, IMammal
{
    public Mammal(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; private set; }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}