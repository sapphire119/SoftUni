namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    //Въпрос за тая задача отностно методите GetOptionalCarParameters, 
    //GetOptionalEngineParameter,
    //ParseCarParamater,
    //ParseEngineParamater
    public class StartUp
    {
        public static void Main()
        {
            var cars = new List<Car>();
            var engines = new List<Engine>();

            var engineCount = int.Parse(Console.ReadLine());

            for (int count = 0; count < engineCount; count++)
            {
                var engineInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var engine = CreateNewEngine(engineInput);

                engines.Add(engine);
            }

            var carCount = int.Parse(Console.ReadLine());
            for (int count = 0; count < carCount; count++)
            {
                var carInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var carEngine = GetEngine(carInput[1], engines);
                if (carInput == null)
                {
                    continue;
                }
                var car = GetCar(carInput, engines, carEngine);
                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static Car GetCar(string[] carInput, List<Engine> engines, Engine carEngine)
        {
            var carModel = carInput[0];
            var car = new Car(carModel, carEngine);

            GetOptionalCarParameters(carInput, car);
            return car;
        }

        private static void GetOptionalCarParameters(string[] carParameters, Car car)
        {
            if (carParameters.Length == 3)
            {
                car = ParseCarParamater(carParameters[2], car);
            }
            else if (carParameters.Length == 4)
            {
                car = ParseCarParamater(carParameters[2], car);
                car = ParseCarParamater(carParameters[3], car);
            }
        }

        private static Car ParseCarParamater(string carParameter, Car car)
        {
            var isItDisplacement = decimal.TryParse(carParameter, out decimal displacement);
            if (isItDisplacement)
            {
                car.Weight = displacement.ToString();
            }
            else
            {
                car.Color = carParameter;
            }

            return car;
        }

        private static Engine GetEngine(string carEngine, List<Engine> engines)
        {
            return engines.Find(e => e.Model == carEngine);
        }

        private static Engine CreateNewEngine(string[] engineInput)
        {
            var model = engineInput[0];
            var power = engineInput[1];

            var engine = new Engine(model, power);

            GetOptionalEngineParameter(engineInput, engine);

            return engine;
        }

        private static void GetOptionalEngineParameter(string[] engineParameters, Engine engine)
        {
            if (engineParameters.Length == 3)
            {
                engine = ParseEngineParamater(engineParameters[2], engine);
            }
            else if (engineParameters.Length == 4)
            {
                engine = ParseEngineParamater(engineParameters[2], engine);
                engine = ParseEngineParamater(engineParameters[3], engine);
            }
        }

        private static Engine ParseEngineParamater(string engineParamter, Engine engine)
        {
            var isItDisplacement = decimal.TryParse(engineParamter, out decimal displacement);
            if (isItDisplacement)
            {
                engine.Displacement = displacement.ToString();
            }
            else
            {
                engine.Efficiency = engineParamter;
            }

            return engine;
        }
    }
}
