public interface ICommandInterpreter
{
    ICommand ParseCommand(string currentCommand, string[] data);
}
