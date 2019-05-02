using System;
namespace Employees.App
{
    public class Engine
    {
        private readonly CommandParser commandParser;

        public Engine(CommandParser commandParser)
        {
            this.commandParser = commandParser;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter a command: ");
                    var input = Console.ReadLine().Trim();
                    var data = input.Split();
                    var result = this.commandParser.ParseCommand(data);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}