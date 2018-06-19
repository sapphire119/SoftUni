using _03BarracksFactory.Contracts;

public class AddCommand : Command
{
    
    private IRepository repository;

    
    private IUnitFactory unitFactory;

    public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
        : base(data)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public override string Execute()
    {
        string unitType = this.Data[1];
        IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        this.repository.AddUnit(unitToAdd);
        string output = unitType + " added!";
        return output;
    }
}