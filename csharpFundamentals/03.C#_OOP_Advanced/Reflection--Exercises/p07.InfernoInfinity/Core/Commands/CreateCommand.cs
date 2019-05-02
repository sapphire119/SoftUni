public class CreateCommand : Command
{
    private IItemFactory itemFactory;
    private IRepository repository;

    public CreateCommand(string[] data, IItemFactory itemFactory, IRepository repository) 
        : base(data)
    {
        this.itemFactory = itemFactory;
        this.repository = repository;
    }

    public override void Execute()
    {
        var weaponTokens = this.Data[0].Split();

        var weaponName = this.Data[1];
        var weaponType = weaponTokens[1];
        var rarirtType = weaponTokens[0];

        var weapon = this.itemFactory.CreateWeapon(weaponType, weaponName, rarirtType);

        if (weapon == null) return;

        this.repository.Add(weapon);
    }
}