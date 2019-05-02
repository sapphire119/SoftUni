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
            var carInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (carInput.Length == 3)
            {
                var carModel = carInput[0];
                var fuelAmount = decimal.Parse(carInput[1]);
                var fuelConsumptionPerKm = decimal.Parse(carInput[2]);

                var doesCarAlreadyExist = cars.Find(c => c.Model == carModel);
                if (doesCarAlreadyExist == null)
                {
                    var car = new Car(carModel, fuelAmount, fuelConsumptionPerKm);
                    cars.Add(car);
                }
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandArgs.Length == 3 && commandArgs[0] == "Drive")
            {
                var carToDrive = commandArgs[1];
                var amountDistance = decimal.Parse(commandArgs[2]);

                var existingCar = cars.Find(c => c.Model == carToDrive);
                if (existingCar != null)
                {
                    existingCar.DriveCar(amountDistance);
                }
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, cars));
    }
}

