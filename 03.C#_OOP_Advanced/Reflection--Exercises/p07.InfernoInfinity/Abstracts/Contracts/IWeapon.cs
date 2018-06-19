public interface IWeapon
{
    string Name { get; }
    int MinDamage { get; }
    int MaxDamage { get; }
    IGem[] Gems { get; }
    WeaponRarityType RarityType { get; }
    void AddGem(int socketIndex, IGem gem);
    void RemoveGem(int socketIndex);
}