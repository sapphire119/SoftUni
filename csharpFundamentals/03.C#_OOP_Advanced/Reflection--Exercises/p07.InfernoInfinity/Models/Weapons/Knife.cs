public class Knife : Weapon
{
    private const int DefaultMinDamage = 3;
    private const int DefaultMaxDamage = 4;

    public Knife(WeaponRarityType rarityType, string name)
        : base(name, DefaultMinDamage * (int)rarityType, DefaultMaxDamage * (int)rarityType, new Gem[2], rarityType)
    {
    }
}