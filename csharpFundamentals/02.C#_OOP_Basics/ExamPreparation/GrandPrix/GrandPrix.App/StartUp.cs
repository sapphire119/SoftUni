namespace GrandPrix.App
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            RaceTower raceTower = new RaceTower();

            var numberOfLapsInRace = int.Parse(Console.ReadLine());
            var trackLength = int.Parse(Console.ReadLine());

            raceTower.SetTrackInfo(numberOfLapsInRace, trackLength);

            while (Track.TotalNumberOfLaps > Track.CompletedLaps)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = inputArgs[0];

                switch (currentCommand)
                {
                    case "RegisterDriver": raceTower.RegisterDriver(inputArgs.Skip(1).ToList()); break;
                    case "Leaderboard": Console.WriteLine(raceTower.GetLeaderboard()); break;
                    case "CompleteLaps":
                        var result = raceTower.CompleteLaps(inputArgs.Skip(1).ToList());
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            Console.WriteLine(result);
                        };
                        break;
                    case "Box": raceTower.DriverBoxes(inputArgs.Skip(1).ToList());break;
                    case "ChangeWeather": raceTower.ChangeWeather(inputArgs.Skip(1).ToList()); break;
                    default:
                        break;
                }
            }

            var winningDriver = raceTower.GetWinner();
            Console.WriteLine($"{winningDriver.Name} wins the race for {winningDriver.TotalTime:f3} seconds.");
        }
    }
}
