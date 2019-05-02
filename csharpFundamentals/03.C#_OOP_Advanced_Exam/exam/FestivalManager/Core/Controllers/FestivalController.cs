namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using Constants;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";

        private readonly IStage stage;
        private readonly ISetFactory setFactory;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISongFactory songFactory;

        public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISongFactory songFactory)
        {
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
            this.stage = stage;
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];  

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);   

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song.Name} ({song.Duration:mm\\:ss}) to {set.Name}";
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            if (totalFestivalLength.Hours >= 1)
            {
                var totalMinutes = totalFestivalLength.TotalMinutes;
                var seconds = totalFestivalLength.Seconds;
                result += ($"Festival length: {totalMinutes}:{seconds:d2}") + "\n";
            }
            else
            {
                result += ($"Festival length: {totalFestivalLength.ToString(TimeFormat)}") + "\n";
            }


            foreach (var set in this.stage.Sets)
            {
                if (set.ActualDuration.Hours >= 1)
                {
                    var totalMinutes = set.ActualDuration.TotalMinutes;
                    var seconds = set.ActualDuration.Seconds;
                    result += ($"--{set.Name} ({totalMinutes}:{seconds:d2}):") + "\n";
                }
                else
                {
                    result += ($"--{set.Name} ({set.ActualDuration.ToString(TimeFormat)}):") + "\n";
                }


                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }

        public string RegisterSet(string[] args)
        {
            var name = args[0];
            var type = args[1];
            var set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return string.Format(Constants.RegisteredSet, type);
        }

        public string RegisterSong(string[] args)
        {
            var songName = args[0];

            var timeSpan = args[1].Split(':');

            var minutes = int.Parse(timeSpan[0]);
            var seconds = int.Parse(timeSpan[1]);

            var length = new TimeSpan();
            try
            {
                length =  new TimeSpan(0, minutes, seconds);
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }

            var song = this.songFactory.CreateSong(songName, length);

            this.stage.AddSong(song);

            return $"Registered song {song.Name} ({song.Duration:mm\\:ss})";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instruments = args.Skip(2).ToArray().Select(i => this.instrumentFactory.CreateInstrument(i)).ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(Constants.RegisteredPerformer, performer.Name);/*$"Registered performer {performer.Name}"*/;
        }
    }
}