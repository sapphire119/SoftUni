namespace Minedraft.App
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            DraftManager draftManager = new DraftManager();
            string command;

            while ((command = Console.ReadLine()) != "Shutdown")
            {
                var commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                var currentCommand = commandArgs[0];

                switch (currentCommand)
                {
                    case "RegisterHarvester": Console.WriteLine(draftManager.RegisterHarvester(commandArgs.Skip(1).ToList())); ; break;
                    case "RegisterProvider": Console.WriteLine(draftManager.RegisterProvider(commandArgs.Skip(1).ToList())); ; break;
                    case "Day": Console.WriteLine(draftManager.Day()); ;break;
                    case "Mode": Console.WriteLine(draftManager.Mode(commandArgs.Skip(1).ToList())); ; break;
                    case "Check": Console.WriteLine(draftManager.Check(commandArgs.Skip(1).ToList())); ; break;
                    default:
                        break;
                }
            }

            Console.WriteLine(draftManager.ShutDown());
        }
    }
}
