namespace p12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command;

            var people = new List<Person>();

            while ((command = Console.ReadLine()) != "End")
            {
                var input = command.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var personName = input[0];

                var existingPerson = people.Find(p => p.Name == personName);

                if (existingPerson == null)
                {
                    var person = new Person(personName);
                    people.Add(person);
                }

                var token = input[1];
                var restOfInput = input.Skip(2).ToArray();
                switch (token)
                {
                    case "company": AddCompany(personName, restOfInput, people); break;
                    case "pokemon": AddPokemon(personName, restOfInput, people); break;
                    case "parents": AddParent(personName, restOfInput, people); break;
                    case "children": AddChild(personName, restOfInput, people); break;
                    case "car": AddCar(personName, restOfInput, people); break;
                    default:
                        break;
                }
            }

            var personToLookFor = Console.ReadLine().Split();
            if (personToLookFor.Length == 1)
            {
                var personToPrint = people.Find(p => p.Name == personToLookFor[0]);
                Console.WriteLine(personToPrint);
            }
        }

        private static void AddCar(string personName, string[] restOfInput, List<Person> people)
        {
            var currentPerson = people.Find(p => p.Name == personName);

            var carModel = restOfInput[0];
            var carSpeed = decimal.Parse(restOfInput[1]);

            currentPerson.Car = new Car(carModel, carSpeed);
        }

        private static void AddChild(string personName, string[] restOfInput, List<Person> people)
        {
            var currentPerson = people.Find(p => p.Name == personName);

            var childName = restOfInput[0];
            var birthday = restOfInput[1];

            var existingChild = currentPerson.Children.Find(c => c.Name == childName);

            if (existingChild == null)
            {
                currentPerson.Children.Add(new Child(childName, birthday));
            }
        }

        private static void AddParent(string personName, string[] restOfInput, List<Person> people)
        {
            var currentPerson = people.Find(p => p.Name == personName);

            var parentName = restOfInput[0];
            var birthday = restOfInput[1];

            var existingParent = currentPerson.Parents.Find(p => p.Name == parentName);
            if (existingParent == null)
            {
                currentPerson.Parents.Add(new Parent(parentName, birthday));
            }
        }

        private static void AddPokemon(string personName, string[] restOfInput, List<Person> people)
        {
            var currentPerson = people.Find(p => p.Name == personName);

            var pokemonName = restOfInput[0];
            var pokemonType = restOfInput[1];


            var doesPokemonAlreadyExist = currentPerson.Pokemons.Find(p => p.Name == pokemonName);
            if (doesPokemonAlreadyExist == null)
            {
                currentPerson.Pokemons.Add(new Pokemon(pokemonName, pokemonType));
            }
        }

        private static void AddCompany(string personName, string[] restOfInput, List<Person> people)
        {
            var currentPerson = people.Find(p => p.Name == personName);

            var companyName = restOfInput[0];
            var department = restOfInput[1];
            var salary = decimal.Parse(restOfInput[2]);

            currentPerson.Company = new Company(companyName, department, salary);
        }
    }
}
