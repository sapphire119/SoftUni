using System.Collections.Generic;

public class RegisterCommand : Command
{

    public RegisterCommand(IList<string> arguments) 
        : base(arguments)
    {
    }

    public override string Execute()
    {
        throw new System.NotImplementedException();
    }
}