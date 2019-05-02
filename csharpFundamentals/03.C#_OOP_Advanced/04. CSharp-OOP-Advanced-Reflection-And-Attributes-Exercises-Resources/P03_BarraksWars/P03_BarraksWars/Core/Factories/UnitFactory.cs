namespace _03BarracksFactory.Core.Factories
{
    using System;
    using _03BarracksFactory.Models.Units;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = GetTypeFromInput(unitType);

            var unit = Activator.CreateInstance(type);

            return (IUnit)unit;
        }

        private Type GetTypeFromInput(string unitType)
        {
            switch (unitType)
            {
                case "Swordsman": return typeof(Swordsman);
                case "Archer": return typeof(Archer);
                case "Gunner": return typeof(Gunner);
                case "Horseman": return typeof(Horseman);
                case "Pikeman": return typeof(Pikeman);
                default:
                    throw new ArgumentException("Invalid unit type!");
                    
            }
        }
    }
}
