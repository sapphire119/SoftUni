public interface IRepairable
{
    string PartName { get; }

    decimal PartHoursWorker { get; set; }
}