using System.Linq;
using System.Collections.Generic;

public class WeaponRepository : IRepository
{
    private IList<IWeapon> weapons;

    public WeaponRepository()
    {
        this.weapons = new List<IWeapon>();
    }

    public void Add(IWeapon weapon)
    {
        this.weapons.Add(weapon);
    }

    public void Print()
    {
        throw new System.NotImplementedException();
    }

    public void Remove(string type)
    {
        throw new System.NotImplementedException();
    }

    public IWeapon FindWeapon(string weaponName) => this.weapons.SingleOrDefault(w => w.Name == weaponName);
}