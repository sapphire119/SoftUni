public interface IItemFactory
{
    IWeapon CreateWeapon(string weaponType, string weaponName, string weaponRarirty);
    IGem CreateGem(string gemType, string gemRarirty);
}