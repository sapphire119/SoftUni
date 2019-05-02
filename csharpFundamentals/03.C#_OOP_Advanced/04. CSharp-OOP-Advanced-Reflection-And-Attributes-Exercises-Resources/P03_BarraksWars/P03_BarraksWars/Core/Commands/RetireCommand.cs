using _03BarracksFactory.Contracts;

public class RetireCommand : Command
{
    
    private IRepository repository;

    public RetireCommand(string[] data, IRepository repository) 
        : base(data)
    {
        this.repository = repository;
    }

    public override string Execute()
    {
        string unitType = this.Data[1];
        this.repository.RemoveUnit(unitType);
        string output = string.Concat(unitType, " ", "retired!");
        return output;
    }
}