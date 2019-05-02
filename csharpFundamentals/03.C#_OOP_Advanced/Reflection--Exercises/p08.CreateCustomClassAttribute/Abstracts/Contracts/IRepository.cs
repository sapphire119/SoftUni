public interface IRepository
{
    void Add(IWeapon element);
    void Remove(string type);
    void Print();
    IWeapon FindWeapon(string weaponName);
}