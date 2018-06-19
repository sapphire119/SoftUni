namespace p08.MilitaryElite
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var soldiers = new HashSet<ISoldier>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();

                switch (commandArgs[0])
                {
                    case "Private": CreatePrivate(commandArgs.Skip(1).ToArray(), soldiers); break;
                    case "LeutenantGeneral": CreateLeutenantGeneral(commandArgs.Skip(1).ToArray(), soldiers); break;
                    case "Engineer": CreateEngineer(commandArgs.Skip(1).ToArray(), soldiers); break;
                    case "Commando": CreateCommandO(commandArgs.Skip(1).ToArray(), soldiers); break;
                    case "Spy": CreateSpy(commandArgs.Skip(1).ToArray(), soldiers); break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, soldiers));
        }

        private static void CreateSpy(string[] spyTokens, HashSet<ISoldier> soldiers)
        {
            ValidateSoldier<Spy>(spyTokens, soldiers);
        }

        private static void CreateCommandO(string[] commandoArgs, HashSet<ISoldier> soldiers)
        {
            var isItvalidCorp = Enum.TryParse(commandoArgs[4], out CorpType corp);
            if (!isItvalidCorp)
            {
                return;
            }
            var existingCommando = ValidateSoldier<Commando>(commandoArgs, soldiers);

            var missionArgs = commandoArgs.Skip(5).ToArray();
            for (int index = 1; index < missionArgs.Length; index += 2)
            {
                var missionName = missionArgs[index - 1];
                var isItAValidMission = Enum.TryParse(missionArgs[index], out MissionType missionType);
                if (!isItAValidMission)
                {
                    continue;
                }
                var existingMission = existingCommando.Missions.SingleOrDefault(m => m.MissionCodeName == missionName);

                if (existingMission == null)
                {
                    existingMission = new Mission(missionName, missionType);
                    existingCommando.AddMission(existingMission);
                }
                else if((missionType == MissionType.Finished) && existingMission.MissionState != MissionType.Finished)
                {
                    existingMission.CompleteMission();
                }
            }
        }

        private static void CreateEngineer(string[] engineerTokens, HashSet<ISoldier> soldiers)
        {
            var isItvalidCorp = Enum.TryParse(engineerTokens[4], out CorpType corp);
            if (!isItvalidCorp)
            {
                return;
            }
            var existingEngineer = ValidateSoldier<Engineer>(engineerTokens, soldiers);

            var partsArgs = engineerTokens.Skip(5).ToArray();
            for (int index = 1; index < partsArgs.Length; index += 2)
            {
                var partName = partsArgs[index - 1];
                var partHoursWorked = decimal.Parse(partsArgs[index]);

                var existingPart = existingEngineer.Repairs.SingleOrDefault(r => r.PartName == partName);
                if (existingPart == null)
                {
                    existingPart = new Repair(partName, partHoursWorked);
                    existingEngineer.AddRepair(existingPart);
                }
                else
                {
                    existingPart.PartHoursWorker += partHoursWorked;
                }
            }
        }

        private static void CreateLeutenantGeneral(string[] generalTokens, HashSet<ISoldier> soldiers)
        {
            var existingGeneral = ValidateSoldier<LeutenantGeneral>(generalTokens, soldiers);

            var privateIds = generalTokens.Skip(4).Select(int.Parse).ToArray();
            foreach (var privateId in privateIds)
            {
                var existingPrivate = (IPrivate)soldiers.SingleOrDefault(p => p.Id == privateId);
                if (existingPrivate != null)
                {
                    existingGeneral.AddPrivate(existingPrivate);
                }
            }
        }

        private static void CreatePrivate(string[] privateArgs, HashSet<ISoldier> soldiers)
        {
            ValidateSoldier<Private>(privateArgs, soldiers);
        }

        private static T ValidateSoldier<T>(string[] soldierTokens, HashSet<ISoldier> soldiers)
        {
            var soldierId = int.Parse(soldierTokens[0]);
            var soldierFirstName = soldierTokens[1];
            var soldierLastName = soldierTokens[2];

            var existingSoldier = soldiers.SingleOrDefault(p => p.Id == soldierId);
            if (existingSoldier == null)
            { 
                if (typeof(T) != typeof(Spy))
                {
                    var soldiersalary = double.Parse(soldierTokens[3]);
                    if (typeof(T).Equals(typeof(Private)))
                    {
                        existingSoldier = new Private(soldierId, soldierFirstName, soldierLastName, soldiersalary);
    }
                    else if (typeof(T).Equals(typeof(LeutenantGeneral)))
                    {
                        existingSoldier = new LeutenantGeneral(soldierId, soldierFirstName, soldierLastName, soldiersalary);
}

                    if (typeof(T).Equals(typeof(Commando)) || typeof(T).Equals(typeof(Engineer)))
                    {
                        var corp = Enum.Parse<CorpType>(soldierTokens[4]);
                        if (typeof(T).Equals(typeof(Engineer)))
                        {
                            existingSoldier = new Engineer(soldierId, soldierFirstName, soldierLastName, soldiersalary, corp);
                        }
                        else if (typeof(T).Equals(typeof(Commando)))
                        {
                            existingSoldier = new Commando(soldierId, soldierFirstName, soldierLastName, soldiersalary, corp);
                        }
                    }
                }
                else if (typeof(T).Equals(typeof(Spy)))
                {
                    var isItAValidCode = long.TryParse(soldierTokens[3], out long spyCode);
                    if (!isItAValidCode)
                    {
                        return default(T);
                    }
                    existingSoldier = new Spy(soldierId, soldierFirstName, soldierLastName, spyCode);
                }
                soldiers.Add(existingSoldier);
            }
            return (T) existingSoldier;
        }
    }
}