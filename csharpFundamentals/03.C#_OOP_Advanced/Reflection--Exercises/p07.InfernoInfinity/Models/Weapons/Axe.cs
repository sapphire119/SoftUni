public class Axe : Weapon
{
    private const int DefaultMinDamage = 5;
    private const int DefaultMaxDamage = 10;

    public Axe(WeaponRarityType rarityType, string name)
        : base(name, DefaultMinDamage * (int)rarityType, DefaultMaxDamage * (int)rarityType, new Gem[4], rarityType)
    {
    }
}