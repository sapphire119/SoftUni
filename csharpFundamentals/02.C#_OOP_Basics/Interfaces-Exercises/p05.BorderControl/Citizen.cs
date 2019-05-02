public class Citizen : IEntity
{
    private string id;

    public Citizen(string id)
    {
        this.Id = id;
    }

    public string Id { get; private set; }
}
