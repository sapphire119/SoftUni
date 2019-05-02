namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            var commandType = assembly.GetTypes().SingleOrDefault(t => t.Name == type);

            if (!typeof(IInstrument).IsAssignableFrom(commandType))
            {
                throw new ArgumentException("Invalid Command!");
            }

            var instance = Activator.CreateInstance(commandType, new object[] { });

            return (IInstrument)instance;
        }
	}
}