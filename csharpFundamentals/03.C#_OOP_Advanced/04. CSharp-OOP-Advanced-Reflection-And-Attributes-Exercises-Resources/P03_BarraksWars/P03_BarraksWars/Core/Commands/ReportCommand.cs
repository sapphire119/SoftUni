using _03BarracksFactory.Contracts;

public class ReportCommand : Command
{
    
    private IRepository repository;

    public ReportCommand(string[] data, IRepository repository) 
        : base(data)
    {
        this.repository = repository;
    }

    public override string Execute()
    {
        string output = this.repository.Statistics;
        return output;
    }
}