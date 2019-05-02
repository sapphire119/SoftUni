namespace p10.CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numberOfEngines = int.Parse(Console.ReadLine());

            var engines = new List<Engine>();

            for (int engineCount = 0; engineCount < numberOfEngines; engineCount++)
            {
                var engineInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                var engineModel = engineInput[0];
                var enginePower = engineInput[1];

                var engine = new Engine(engineModel, enginePower);

                if (engineInput.Length == 3)
                {
                    GetOptionalCarParamater(engineInput[2], engine);
                }
                else if (engineInput.Length == 4)
                {
                    GetOptionalCarParamater(engineInput[2], engine);
                    GetOptionalCarParamater(engineInput[3], engine);
                }

                engines.Add(engine);
            }

            var linesOfCars = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int carCount = 0; carCount < linesOfCars; carCount++)
            {
                var carInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var carModel = carInput[0];
                var carEngine = carInput[1];

                var existingEngine = engines.Find(e => e.Model == carEngine);
                if (existingEngine == null)
                {
                    continue;
                }

                var car = new Car(carModel, existingEngine);

                if (carInput.Length == 3)
                {
                    GetOptionalEngineParameter(carInput[2], car);
                }
                else if (carInput.Length == 4)
                {
                    GetOptionalEngineParameter(carInput[2], car);
                    GetOptionalEngineParameter(carInput[3], car);
                }
                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static void GetOptionalEngineParameter(string param, Car car)
        {
            var isitWeightParam = decimal.TryParse(param, out decimal weight);
            if (isitWeightParam)
            {
                car.Weight = weight.ToString();
            }
            else
            {
                car.Color = param;
            }
        }

        private static void GetOptionalCarParamater(string param, Engine engine)
        {
            var isItDisplacement = decimal.TryParse(param, out decimal displacement);
            if (isItDisplacement)
            {
                engine.Displacements = displacement.ToString();
            }
            else
            {
                engine.Efficiency = param;
            }
        }
    }
}
