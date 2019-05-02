public interface IGem
{
    int Strength { get; }
    int Agility { get; }
    int Vitality { get; }
    GemType GemType { get; }
    int AdditiveMinDamage { get; }
    int AdditiveMaxDamage { get; }
}