public abstract class Unit : IUnit
{
    protected Unit(string id)
    {
        this.Id = id;
    }

    public string Id { get; set; }

    public abstract string Type { get; }
}