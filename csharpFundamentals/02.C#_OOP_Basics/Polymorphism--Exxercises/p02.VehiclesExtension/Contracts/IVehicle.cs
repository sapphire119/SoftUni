public interface IVehicle
{
    double FuelQuantity { get; }

    double FuelConsumtptionInLitersPerKm { get; }

    double DistanceTraveled { get; }

    double TankCapacity { get; }

    void Refuel(double fuelAmount);

    string TravelDistance(double distance);
}