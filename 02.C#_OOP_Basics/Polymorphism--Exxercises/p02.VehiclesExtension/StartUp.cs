namespace p01.Vehicles
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Vehicle[] vehicles = new Vehicle[3];
            for (int count = 0; count < 3; count++)
            {
                var input = ReadInput();
                var vehicleType = input[0];

                var vehicleFuelQuantity = double.Parse(input[1]);
                var vehicleLitersPerKm = double.Parse(input[2]);
                var vehicleTankCapacity = double.Parse(input[3]);

                var fuelToPutInGasTank = vehicleFuelQuantity <= vehicleTankCapacity ? vehicleFuelQuantity : 0.0;

                switch (vehicleType)
                {
                    case "Car":
                        vehicles[0] = new Car(fuelToPutInGasTank, vehicleLitersPerKm, vehicleTankCapacity);
                        break;
                    case "Truck":
                        vehicles[1] = new Truck(fuelToPutInGasTank, vehicleLitersPerKm, vehicleTankCapacity);
                        break;
                    case "Bus":
                        vehicles[2] = new Bus(fuelToPutInGasTank, vehicleLitersPerKm, vehicleTankCapacity);
                        break;
                    default:
                        break;
                }
            }

            Car car = (Car)vehicles[0];
            Truck truck = (Truck)vehicles[1];
            Bus bus = (Bus)vehicles[2];

            var lines = int.Parse(Console.ReadLine());

            for (int count = 0; count < lines; count++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                var currentCommand = commandArgs[0];

                try
                {
                    switch (currentCommand)
                    {
                        case "Drive":
                            var busEmptyFuelConsumption = bus.FuelConsumtptionInLitersPerKm;
                            var busSummerConsumption = busEmptyFuelConsumption + 1.4;
                            bus.SwitchFuelConsumption(busSummerConsumption);
                            DriveVehicle(commandArgs.Skip(1).ToArray(), car, truck, bus);
                            bus.SwitchFuelConsumption(busEmptyFuelConsumption);
                            break;
                        case "DriveEmpty":
                            //var busFullFuelConsumption = bus.FuelConsumtptionInLitersPerKm;
                            //bus.SwitchFuelConsumption(busFullFuelConsumption);
                            DriveVehicle(commandArgs.Skip(1).ToArray(), car, truck, bus);
                            //bus.SwitchFuelConsumption(busFullFuelConsumption);
                            break;
                        case "Refuel": RefuelVehicle(commandArgs.Skip(1).ToArray(), car, truck, bus); break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void RefuelVehicle(string[] refuelTokens, Car car, Truck truck, Bus bus)
        {
            var vehicleType = refuelTokens[0];
            var fuelAmountToRefill = double.Parse(refuelTokens[1]);

            switch (vehicleType)
            {
                case "Car":car.Refuel(fuelAmountToRefill);break;
                case "Truck": truck.Refuel(fuelAmountToRefill); break;
                case "Bus": bus.Refuel(fuelAmountToRefill); break;
                default:
                    break;
            }
        }

        private static void DriveVehicle(string[] driveTokens, Car car, Truck truck, Bus bus)
        {
            var vehicleType = driveTokens[0];
            var distance = double.Parse(driveTokens[1]);

            switch (vehicleType)
            {
                case "Car": Console.WriteLine(car.TravelDistance(distance)); break;
                case "Truck": Console.WriteLine(truck.TravelDistance(distance)); break;
                case "Bus": Console.WriteLine(bus.TravelDistance(distance)); break;
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
