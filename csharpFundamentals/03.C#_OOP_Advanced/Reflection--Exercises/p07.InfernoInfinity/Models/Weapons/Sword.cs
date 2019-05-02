public class Sword : Weapon
{
    private const int DefaultMinDamage = 4;
    private const int DefaultMaxDamage = 6;

    public Sword(WeaponRarityType rarityType, string name)
        : base(name, DefaultMinDamage * (int)rarityType, DefaultMaxDamage * (int)rarityType, new Gem[3], rarityType)
    {
    }
}