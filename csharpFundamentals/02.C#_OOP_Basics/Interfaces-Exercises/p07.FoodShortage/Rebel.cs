public class Rebel : IRebel
{
    private const long RebelPurchasingPower = 5L;

    private long rebelFood;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
        this.rebelFood = 0L;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Group { get; private set; }

    public long BoughtFood => this.rebelFood;

    public void BuyFood()
    {
        this.rebelFood += RebelPurchasingPower;
    }
}