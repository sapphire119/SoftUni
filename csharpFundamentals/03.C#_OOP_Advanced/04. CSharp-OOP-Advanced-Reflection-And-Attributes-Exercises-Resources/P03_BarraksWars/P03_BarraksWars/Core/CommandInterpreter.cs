using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        var assembly = Assembly.GetCallingAssembly();

        var commandTypes = assembly.GetTypes()
                  .Where(t => t.IsSubclassOf(typeof(Command)))
                  .ToArray();

        var newCommandName = string.Concat(commandName[0].ToString().ToUpper(), commandName.Substring(1));

        var command = commandTypes.SingleOrDefault(c => c.Name == $"{newCommandName}Command");

        if (command == null)
        {
            throw new ArgumentException("Invalid command!");
        }

        var constructor = command.GetConstructors().FirstOrDefault();

        var paramters = constructor.GetParameters().Select(p => p.ParameterType).ToArray();

        var services = paramters.Select(this.serviceProvider.GetService).ToArray();
        services[0] = data;
        //var constructorParameters = constructor
        //            .GetParameters()
        //            .Select(pi => pi.ParameterType)
        //            .ToArray();

        //var services = constructorParameters
        //        .Select(serviceProvider.GetService)
        //        .ToArray();

        return (IExecutable)constructor.Invoke(services);
    }
}