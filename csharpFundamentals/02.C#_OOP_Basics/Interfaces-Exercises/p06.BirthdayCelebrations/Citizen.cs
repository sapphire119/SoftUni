public class Citizen : IEntity
{
    private string birthDate;

    public Citizen(string birthDate)
    {
        this.BirthDate = birthDate;
    }

    public string BirthDate { get; private set; }
}
