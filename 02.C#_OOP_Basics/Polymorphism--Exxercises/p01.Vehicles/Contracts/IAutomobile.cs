public interface IAutomobile
{
    double FuelQuantity { get; }

    double FuelConsumtptionInLitersPerKm { get; }

    double DistanceTraveled { get; }

    void Refuel(double fuelAmount);

    string TravelDistance(double distance);
}