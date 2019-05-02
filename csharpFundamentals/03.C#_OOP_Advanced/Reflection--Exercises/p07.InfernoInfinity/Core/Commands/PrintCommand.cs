public class PrintCommand : Command
{
    private IWriteable writeable;
    private IRepository repository;

    public PrintCommand(string[] data, IWriteable writeable, IRepository repository) 
        : base(data)
    {
        this.writeable = writeable;
        this.repository = repository;
    }

    public override void Execute()
    {
        string weaponName = this.Data[0];
        var existingWeapon = this.repository.FindWeapon(weaponName);
        if (existingWeapon == null) return;
        this.writeable.WriteLine(existingWeapon);
    }
}