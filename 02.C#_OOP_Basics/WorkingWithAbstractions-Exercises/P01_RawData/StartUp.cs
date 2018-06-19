using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int count = 0; count < lines; count++)
            {
                var inputParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputParameters.Length == 13)
                {
                    var car = GetCar(inputParameters);
                    cars.Add(car);
                }
            }

            var command = Console.ReadLine();
            switch (command)
            {
                case "fragile":PrintFragileCars(cars);break;
                case "flamable":PrintFlammableCars(cars);break;
                default:
                    break;
            }
        }

        private static Car GetCar(string[] inputParameters)
        {
            var carModel = inputParameters[0];

            var engine = GetEngine(inputParameters.Skip(1).Take(2).ToArray());
            var cargo = GetCargo(inputParameters.Skip(3).Take(2).ToArray());

            var tires = GetTires(inputParameters.Skip(5).ToArray());

            var car = new Car(carModel, engine, cargo);
            car.Tires.AddRange(tires);

            return car;
        }

        private static List<Tire> GetTires(string[] tireParameters)
        {
            var tires = new List<Tire>();

            for (int count = 1; count < tireParameters.Length; count += 2) 
            {
                var tirePressure = decimal.Parse(tireParameters[count - 1]);
                var tireAge = int.Parse(tireParameters[count]);

                var currentTire = new Tire(tirePressure, tireAge);

                tires.Add(currentTire);
            }

            return tires;
        }

        private static Cargo GetCargo(string[] cargoParameters)
        {
            var cargoWeight = int.Parse(cargoParameters[0]);
            var cargoType = cargoParameters[1];

            var currentCargo = new Cargo(cargoWeight, cargoType);
            return currentCargo;
        }

        private static Engine GetEngine(string[] engineParameters)
        {
            var engineSpeed = decimal.Parse(engineParameters[0]);
            var enginePower = decimal.Parse(engineParameters[1]);

            var currentEngine = new Engine(engineSpeed, enginePower);

            return currentEngine;
        }

        private static void PrintFlammableCars(List<Car> cars)
        {
            List<Car> flamableCars = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamableCars));
        }

        private static void PrintFragileCars(List<Car> cars)
        {
            List<Car> fragileCars = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1.0M))
                    .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragileCars));
        }
    }
}
