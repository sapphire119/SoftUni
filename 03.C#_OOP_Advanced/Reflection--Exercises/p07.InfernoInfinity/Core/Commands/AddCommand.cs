public class AddCommand : Command
{
    private IItemFactory unitFactory;
    private IRepository repository;

    public AddCommand(string[] data, IItemFactory unitFactory, IRepository repository) 
        : base(data)
    {
        this.unitFactory = unitFactory;
        this.repository = repository;
    }

    public override void Execute()
    {
        string[] gemTokens = this.Data[2].Split();

        string weaponName = this.Data[0];
        int socketIndex = int.Parse(this.Data[1]);
        string gemRarity = gemTokens[0];
        string gemType = gemTokens[1];

        var existingWeapon = this.repository.FindWeapon(weaponName);
        if (existingWeapon == null) return;

        var gem = this.unitFactory.CreateGem(gemType, gemRarity);
        if (gem == null) return;

        existingWeapon.AddGem(socketIndex, gem);
    }
}