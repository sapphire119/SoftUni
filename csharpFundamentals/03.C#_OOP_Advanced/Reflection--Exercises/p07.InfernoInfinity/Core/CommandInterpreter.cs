using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public ICommand ParseCommand(string currentCommand, string[] data)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        var commands = assembly.GetTypes().Where(c => c.IsSubclassOf(typeof(Command)));

        var commandToExecute = commands.SingleOrDefault(c => c.Name == $"{currentCommand}Command");

        if (commandToExecute == null)
        {
            throw new ArgumentException("Invalid command!");
        }

        var constructor = commandToExecute.GetConstructors().First();

        var parameters = constructor.GetParameters().Select(p => p.ParameterType).ToArray();

        var services = parameters.Select(this.serviceProvider.GetService).ToArray();
        services[0] = data;



        return (ICommand)constructor.Invoke(services);
    }
}