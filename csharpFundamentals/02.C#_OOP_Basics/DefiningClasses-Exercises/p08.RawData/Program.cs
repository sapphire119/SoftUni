using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var linesCount = int.Parse(Console.ReadLine());

        var cars = new List<Car>();

        for (int count = 0; count < linesCount; count++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 13)
            {
                var carModel = input[0];
                var engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                var cargo = new Cargo(int.Parse(input[3]), input[4]);

                var car = new Car(carModel, engine, cargo);

                var tiresArgs = input.Skip(5).ToArray();
                for (int i = 1, index = 0; i <= tiresArgs.Length && index < 4; i+= 2,index++)
                {
                    var tirePressure = decimal.Parse(tiresArgs[i - 1]);
                    var tireAge = int.Parse(tiresArgs[i]);
                    car.Tires[index] = new Tire(tirePressure, tireAge);
                }

                cars.Add(car);
            }
        }

        var command = Console.ReadLine();

        if (command == "fragile")
        {
            var carsWhosePressureIsBelowOne = cars.Where(c => c.Tires.Any(t => t.Pressure < 1)).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, carsWhosePressureIsBelowOne));
        }
        else if (command == "flamable")
        {
            var carsWhoHaveStrongEngines = cars.Where(c => c.Engine.Power > 250).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, carsWhoHaveStrongEngines));
        }
    }
}

