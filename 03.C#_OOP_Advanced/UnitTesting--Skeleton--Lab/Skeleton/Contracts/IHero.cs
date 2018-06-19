public interface IHero
{
    int Experience { get; }
    string Name { get; }
    IAxe Weapon { get; }

    void Attack(IDummy target);
}