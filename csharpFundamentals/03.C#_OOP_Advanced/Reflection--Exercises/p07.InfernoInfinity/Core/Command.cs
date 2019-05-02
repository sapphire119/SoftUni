public abstract class Command : ICommand
{
    protected Command(string[] data)
    {
        this.Data = data;
    }

    public string[] Data { get; set; }

    public abstract void Execute();
}