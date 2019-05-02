namespace p01.Vehicles
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var carInput = ReadInput();
            var truckInput = ReadInput();

            var carFuelQunatity = double.Parse(carInput[1]);
            var carFuelConsumptionPerKm = double.Parse(carInput[2]);

            var truckFuelQuantity = double.Parse(truckInput[1]);
            var truckFuelConsumptionPerKm = double.Parse(truckInput[2]);

            var car = new Car(carFuelQunatity, carFuelConsumptionPerKm);
            var truck = new Truck(truckFuelQuantity, truckFuelConsumptionPerKm);

            var lines = int.Parse(Console.ReadLine());

            for (int count = 0; count < lines; count++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                var currentCommand = commandArgs[0];

                switch (currentCommand)
                {
                    case "Drive": DriveVehicle(commandArgs.Skip(1).ToArray(), car, truck); break;
                    case "Refuel": RefuelVehicle(commandArgs.Skip(1).ToArray(), car, truck); break;
                    default:
                        break;
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void RefuelVehicle(string[] refuelTokens, Car car, Truck truck)
        {
            var vehicleType = refuelTokens[0];
            var fuelAmountToRefill = double.Parse(refuelTokens[1]);

            switch (vehicleType)
            {
                case "Car": car.Refuel(fuelAmountToRefill); break;
                case "Truck": truck.Refuel(fuelAmountToRefill); break;
                default:
                    break;
            }
        }

        private static void DriveVehicle(string[] driveTokens, Car car, Truck truck)
        {
            var vehicleType = driveTokens[0];
            var distance = double.Parse(driveTokens[1]);

            switch (vehicleType)
            {
                case "Car": Console.WriteLine(car.TravelDistance(distance)); break;
                case "Truck": Console.WriteLine(truck.TravelDistance(distance)); break;
                default:
                    break;
            }
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine().Split().ToArray();
        }
    }
}
