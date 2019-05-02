namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;


    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            var commandType = assembly.GetTypes().SingleOrDefault(t => t.Name == type);

            if (!typeof(ISet).IsAssignableFrom(commandType))
            {
                throw new ArgumentException("Invalid Command!");
            }

            var instance = Activator.CreateInstance(commandType, new object[] { name });

            return (ISet)instance;
		}
	}




}
