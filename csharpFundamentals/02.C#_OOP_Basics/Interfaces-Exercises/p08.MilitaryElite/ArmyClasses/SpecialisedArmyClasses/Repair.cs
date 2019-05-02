public class Repair : IRepairable
{
    public Repair() { }

    public Repair(string partName, decimal partHoursWorker)
        : this()
    {
        this.PartName = partName;
        this.PartHoursWorker = partHoursWorker;
    }

    public string PartName { get; private set; }

    public decimal PartHoursWorker { get; set; }
}