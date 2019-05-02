using System;

public class ItemFactory : IItemFactory
{
    public IGem CreateGem(string gemType, string gemRarirty)
    {
        Type type = Type.GetType(gemType);
        if (type == null) return null;

        var isValidGemRarirty = Enum.TryParse(gemRarirty, out GemType rarirtType);

        if (!isValidGemRarirty) return null;

        var gemInstance = Activator.CreateInstance(type, new object[] { rarirtType });

        return (IGem)gemInstance;
    }

    public IWeapon CreateWeapon(string weaponType, string weaponName, string weaponRarirty)
    {
        Type type = Type.GetType(weaponType);
        if (type == null) return null;

        var isItAValidWEaponType = Enum.TryParse(weaponRarirty, out WeaponRarityType rarityType);

        if (!isItAValidWEaponType) return null;

        var weaponInstance = Activator.CreateInstance(type, new object[] { rarityType, weaponName });

        return (IWeapon)weaponInstance;
    }
}