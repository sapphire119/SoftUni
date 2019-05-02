namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;
	using Instruments;

	public class Performer : IPerformer
	{
		private readonly List<IInstrument> instruments;

		public Performer(string name, int age, params IInstrument[] instruments)
		{
			this.Name = name;
			this.Age = age;
            this.instruments = instruments.ToList();
		}

		public string Name { get; }

		public int Age { get; }

		public IReadOnlyCollection<IInstrument> Instruments => (IReadOnlyCollection<IInstrument>)this.instruments;

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
