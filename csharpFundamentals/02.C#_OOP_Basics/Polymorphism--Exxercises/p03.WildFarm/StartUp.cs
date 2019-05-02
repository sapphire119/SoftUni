namespace p03.WildFarm
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var animals = new List<Animal>();
            string command;
            long count = 0;
            Animal currentAnimal = null;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (count % 2 == 0)
                    currentAnimal = CreateAnimal(commandArgs, animals);
                else
                    ReadOddLine(commandArgs, currentAnimal);
                count++;
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }

        private static void ReadOddLine(string[] foodTokens, Animal currentAnimal)
        {
            try
            {
                Console.WriteLine(currentAnimal.ProduceSound());

                currentAnimal.EatFood(foodTokens);
                currentAnimal = null;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static Animal CreateAnimal(string[] commandArgs, List<Animal> animals)
        {
            Animal animal = null;
            if (commandArgs.Length >= 4)
            {
                animal = ParseAnimal(commandArgs, animals);
            }
            return animal;
        }

        private static Animal ParseAnimal(string[] commandArgs, List<Animal> animals)
        {
            var animalType = commandArgs[0];
            var animalName = commandArgs[1];
            var isItANumber = double.TryParse(commandArgs[2], out double animalWeight);
            if (!isItANumber)
            {
                return default(Animal);
            }

            Animal animal = null;

            var wingSize = 0.0;
            if (animalType == nameof(Owl) || animalType == nameof(Hen))
            {
                var isItDouble = double.TryParse(commandArgs[3], out wingSize);
                if (!isItDouble)
                {
                    return default(Animal);
                }
            }

            switch (animalType)
            {
                case "Cat": animal = new Cat(animalName, animalWeight, 0, commandArgs[3], commandArgs[4]); break;
                case "Tiger": animal = new Tiger(animalName, animalWeight, 0, commandArgs[3], commandArgs[4]); break;
                case "Owl": animal = new Owl(animalName, animalWeight, 0, double.Parse(commandArgs[3])); break;
                case "Hen": animal = new Hen(animalName, animalWeight, 0, double.Parse(commandArgs[3])); break;
                case "Mouse": animal = new Mouse(animalName, animalWeight, 0, commandArgs[3]); break;
                case "Dog": animal = new Dog(animalName, animalWeight, 0, commandArgs[3]); break;
                default:
                    return default(Animal);
            }
            animals.Add(animal);

            return animal;
        }
    }
}