using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IEnergyRepository energyRepository;
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IEnergyRepository energyRepository, IServiceProvider serviceProvider)
    {
        this.energyRepository = energyRepository;
        this.HarvesterController = new HarvesterController(this.energyRepository);
        this.ProviderController = new ProviderController(this.energyRepository);
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        var command = InterpretCommand(args, serviceProvider);
        var result = command.Execute();
        return result;
    }

    private ICommand InterpretCommand(IList<string> args, IServiceProvider serviceProvider)
    {
        var commandName = args[0];

        var currentCommand = Assembly.GetCallingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Command)))
            .SingleOrDefault(c => c.Name == $"{commandName}Command");

        if (!currentCommand.IsAssignableFrom(typeof(Command)))
        {
            throw new ArgumentException("Invalid command!");
        }

        var constructor = currentCommand.GetConstructors().First();

        var paramtersInfos = constructor.GetParameters();
        object[] parameters = new object[paramtersInfos.Length];

        for (int i = 0; i < paramtersInfos.Length; i++)
        {
            Type paramtype = paramtersInfos[i].ParameterType;

            if (paramtersInfos[i].GetType() == typeof(IList<string>))
            {
                parameters[i] = args;
            }
            else
            {
                PropertyInfo param = this.GetType().GetProperties().FirstOrDefault(p => p.PropertyType == paramtype);

                parameters[i] = param.GetValue(this);
            }
        }

        object instace = constructor.Invoke(parameters);
        return (ICommand)instace;
    }
}