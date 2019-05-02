using System;
using System.Linq;

public class Engine
{
    private readonly IReadable reader;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReadable readable, ICommandInterpreter commandInterpreter)
    {
        this.reader = readable;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        string input;
        while ((input = reader.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

            string currentCommand = inputArgs[0];

            string[] data = inputArgs.Skip(1).ToArray();
            var command = this.commandInterpreter.ParseCommand(currentCommand, data);
            command.Execute();
        }
    }
}