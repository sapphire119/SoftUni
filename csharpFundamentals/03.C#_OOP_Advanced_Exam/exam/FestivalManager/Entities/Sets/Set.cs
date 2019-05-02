namespace FestivalManager.Entities.Sets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Constants;

    public abstract class Set : ISet
    {
        private IList<IPerformer> performers;
        private IList<ISong> songs;

        protected Set(string name, TimeSpan maxDuration)
        {
            this.Name = name;
            this.MaxDuration = maxDuration;

            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; private set; }

        public TimeSpan MaxDuration { get; private set; }

        public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));/*CalculateTotalDurationOfSongs();*/

        public IReadOnlyCollection<IPerformer> Performers => (IReadOnlyCollection<IPerformer>)this.performers;

        public IReadOnlyCollection<ISong> Songs => (IReadOnlyCollection<ISong>)this.songs;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration + this.ActualDuration > this.MaxDuration)
            {
                throw new InvalidOperationException(Constants.SongOverSetLimit);
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (!this.Performers.Any())
            {
                return false;
            }

            if (!this.Songs.Any())
            {
                return false;
            }

            var allPerformersHaveInstruments = this.Performers.All(p => p.Instruments.Any());

            if (!allPerformersHaveInstruments)
            {
                return false;
            }

            var allPerformersHaveFunctioningInstruments = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (!allPerformersHaveFunctioningInstruments)
            {
                return false;
            }

            return true;
        }
    }
}
