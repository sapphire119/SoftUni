namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;
    using System;
    using System.Linq;

    /// <summary>
    /// by g0shk0
    /// </summary>
    public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

        private IFestivalController festivalController;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setCоntroller = setController;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "END")
            {
                try
                {
                    var result = ProcessCommand(command);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine($"ERROR: {ex.Message}");
                }
            }

            var endResult = "Results:" + Environment.NewLine + this.festivalController.ProduceReport();
            this.writer.WriteLine(endResult.Trim());
        }

        public string ProcessCommand(string input)
        {
            string commandResult = string.Empty;

            var commandArgs = input.Split();
            var restOfArgs = commandArgs.Skip(1).ToArray();

            var currentCommand = commandArgs[0];

            switch (currentCommand)
            {
                case "RegisterSet": commandResult = this.festivalController.RegisterSet(restOfArgs); break;
                case "SignUpPerformer": commandResult = this.festivalController.SignUpPerformer(restOfArgs);break;
                case "RegisterSong": commandResult =  this.festivalController.RegisterSong(restOfArgs); break;
                case "AddSongToSet": commandResult =  this.festivalController.AddSongToSet(restOfArgs); break;
                case "AddPerformerToSet": commandResult = this.festivalController.AddPerformerToSet(restOfArgs);break;
                case "RepairInstruments": commandResult = this.festivalController.RepairInstruments(restOfArgs);break;
                case "LetsRock": commandResult =  this.setCоntroller.PerformSets(); break;
            }

            return commandResult;

            //throw new ArgumentException();
        }

  //      public void RUn()
		//{
		//	while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
		//	{
		//		var input = chetach.ReadLine();

		//		if (input == "END")
		//			break;

		//		try
		//		{
		//			string.Intern(input);

		//			var result = this.DoCommand(input);
		//			this.pisach.WriteLine(result);
		//		}
		//		catch (Exception ex) // in case we run out of memory
		//		{
		//			this.pisach.WriteLine("ERROR: " + ex.Message);
		//		}
		//	}

		//	var end = this.festivalController.Report();

		//	this.pisach.WriteLine("Results:");
		//	this.pisach.WriteLine(end);
		//}

		//public string DoCommand(string input)
		//{
		//	var chasti = input.Split(" ".ToCharArray().First());

		//	var purvoto = chasti.First();
		//	var parametri = chasti.Skip(1).ToArray();

		//	if (purvoto == "LetsRock")
		//	{
		//		var setovete = this.setController.PerformSets();
		//		return setovete;
		//	}

		//	var festivalcontrolfunction = this.festivalController.GetType()
		//		.GetMethods()
		//		.FirstOrDefault(x => x.Name == purvoto);

		//	string a;

		//	try
		//	{
		//		a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parametri });
		//	}
		//	catch (TargetInvocationException up)
		//	{
		//		throw up; // ha ha
		//	}

		//	return a;
		//}
    }
}