public interface ICitizen : IBuyer, IPerson
{
    string Id { get; }

    string BirthDate { get; }
}