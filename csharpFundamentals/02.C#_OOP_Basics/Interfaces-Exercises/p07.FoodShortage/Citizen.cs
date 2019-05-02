public class Citizen : ICitizen
{
    private const long CitizenPurchasingPower = 10L;

    private long citizenFood;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthdate;
        this.citizenFood = 0L;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }

    public string BirthDate { get; private set; }

    public long BoughtFood => this.citizenFood;

    public void BuyFood()
    {
        this.citizenFood += CitizenPurchasingPower;
    }
}
