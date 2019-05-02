namespace Forum.App.Commands.Contrancts
{
    public interface ICommand
    {
        string Execute(params string[] arguments);
    }
}
