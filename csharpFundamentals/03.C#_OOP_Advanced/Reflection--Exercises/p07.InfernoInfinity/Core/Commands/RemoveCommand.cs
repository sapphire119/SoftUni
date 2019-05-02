public class RemoveCommand : Command
{
    private IRepository repository;

    public RemoveCommand(string[] data, IRepository repository) 
        : base(data)
    {
        this.repository = repository;
    }

    public override void Execute()
    {
        string weaponName = this.Data[0];
        int socketIndex = int.Parse(this.Data[1]);

        var existingWeapon = this.repository.FindWeapon(weaponName);
        if (existingWeapon == null) return;

        existingWeapon.RemoveGem(socketIndex);
    }
}