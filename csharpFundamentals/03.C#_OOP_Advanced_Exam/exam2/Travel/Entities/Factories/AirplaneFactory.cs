namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            var currentType = assembly.GetTypes().SingleOrDefault(t => t.Name == type);

            if (!typeof(IAirplane).IsAssignableFrom(currentType))
            {
                throw new ArgumentException("Invalid Command!");
            }

            var instance = Activator.CreateInstance(currentType);

            return (IAirplane)instance;
        }
	}
}