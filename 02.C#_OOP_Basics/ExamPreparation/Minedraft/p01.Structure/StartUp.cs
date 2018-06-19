namespace p01.Structure
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string command;
            DraftManager draftManager = new DraftManager();
            while (true) 
            {
                command = Console.ReadLine();

                var commandArgs = command.Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();

                var currentCommand = commandArgs[0];
                try
                {
                    switch (currentCommand)
                    {
                        case "RegisterHarvester": Console.WriteLine(draftManager.RegisterHarvester(commandArgs.Skip(1).ToList())); break;
                        case "RegisterProvider": Console.WriteLine(draftManager.RegisterProvider(commandArgs.Skip(1).ToList())); break;
                        case "Day": Console.WriteLine(draftManager.Day()); break;
                        case "Mode": Console.WriteLine(draftManager.Mode(commandArgs.Skip(1).ToList())); break;
                        case "Check": Console.WriteLine(draftManager.Check(commandArgs.Skip(1).ToList())); ; break;
                        case "Shutdown": Console.WriteLine(draftManager.ShutDown()); ; Environment.Exit(0); break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}