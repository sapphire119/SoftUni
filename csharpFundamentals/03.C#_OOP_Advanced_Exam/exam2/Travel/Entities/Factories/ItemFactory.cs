namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            var currentType = assembly.GetTypes().SingleOrDefault(t => t.Name == type);

            if (!typeof(IItem).IsAssignableFrom(currentType))
            {
                throw new ArgumentException("Invalid Command!");
            }

            var instance = Activator.CreateInstance(currentType);

            return (IItem)instance;
		}
	}
}
