using System.Collections.Generic;

public interface IEngineer : ISpecialisedSoldier
{
    IReadOnlyCollection<IRepairable> Repairs { get; }

    void AddRepair(IRepairable repair);
}