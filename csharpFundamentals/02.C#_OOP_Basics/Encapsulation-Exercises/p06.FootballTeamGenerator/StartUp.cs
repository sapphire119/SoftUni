namespace p06.FootballTeamGenerator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var teams = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(';');

                try
                {
                    switch (tokens[0])
                    {
                        case "Team": CreateTeam(tokens.Skip(1).ToArray(), teams); break;
                        case "Add": AddPlayerToTeam(tokens.Skip(1).ToArray(), teams); break;
                        case "Remove": RemovePlayerFromTeam(tokens.Skip(1).ToArray(), teams); break;
                        case "Rating": RateTeam(tokens.Skip(1).ToArray(), teams); break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void RateTeam(string[] tokens, List<Team> teams)
        {
            var teamName = tokens[0];
            var existingTeam = CheckIfTeamExist(teamName, teams);

            Console.WriteLine(existingTeam);
        }

        private static void RemovePlayerFromTeam(string[] tokens, List<Team> teams)
        {
            var teamName = tokens[0];
            var existingTeam = CheckIfTeamExist(teamName, teams);

            var playerName = tokens[1];
            existingTeam.RemovePlayer(playerName);
        }

        private static void AddPlayerToTeam(string[] playerTokens, List<Team> teams)
        {
            //•	If you receive a command to add a player to a missing team, print "Team [team name] does not exist."
            var teamName = playerTokens[0];

            var existingTeam = CheckIfTeamExist(teamName, teams);

            var playerName = playerTokens[1];

            var existingPlayer = existingTeam.Players.SingleOrDefault(p => p.Name == playerName);
            if (existingPlayer != null)
            {
                return;
            }

            var playerEndurance = int.Parse(playerTokens[2]);
            var playerSprint = int.Parse(playerTokens[3]);
            var playerDribble = int.Parse(playerTokens[4]);
            var playerPassing = int.Parse(playerTokens[5]);
            var playerShooting = int.Parse(playerTokens[6]);

            var playerStats = new Statistic(playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);

            var player = new Player(playerName, playerStats);

            existingTeam.AddPlayer(player);

        }

        private static void CreateTeam(string[] teamTokens, List<Team> teams)
        {
            var teamName = teamTokens[0];

            var existingTeam = teams.Find(t => t.Name == teamName);
            if (existingTeam == null)
            {
                existingTeam = new Team(teamName);
                teams.Add(existingTeam);
            }
        }

        private static Team CheckIfTeamExist(string teamName, List<Team> teams)
        {
            var existingTeam = teams.Find(t => t.Name == teamName);
            if (existingTeam == null)
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }
            return existingTeam;
        }
    }
}
