namespace Forum.App.Commands
{
    using System;

    using Forum.App.Commands.Contrancts;

    public class ExitCommand : ICommand
    {
        public string Execute(params string[] arguments)
        {
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
