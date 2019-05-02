public interface IAxe
{
    int AttackPoints { get; }
    int DurabilityPoints { get; }

    void Attack(IDummy target);
}