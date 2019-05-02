namespace p11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var trainers = new List<Trainer>();

            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                var trainerInput = command.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (trainerInput.Length == 4)
                {
                    var trainerName = trainerInput[0];
                    var pokemonName = trainerInput[1];
                    var pokemonElement = trainerInput[2];
                    var pokemonHealth = decimal.Parse(trainerInput[3]);

                    var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                    var existingTrainer = trainers.Find(t => t.Name == trainerName);
                    if (existingTrainer != null)
                    {
                        existingTrainer.Pokemons.Add(pokemon);
                    }
                    else
                    {
                        var trainer = new Trainer(trainerName);
                        trainer.Pokemons.Add(pokemon);

                        trainers.Add(trainer);
                    }
                }
            }

            string elementCommand;
            while ((elementCommand = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    var existingPokemon = trainer.Pokemons.Find(p => p.Element == elementCommand);
                    if (existingPokemon != null)
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        //Питай дали това може да се напише по, по-добър начин
                        if (trainer.Pokemons.Count != 0)
                        {
                            trainer.Pokemons = trainer.Pokemons.Select(p => new Pokemon
                            {
                                Element = p.Element,
                                Name = p.Name,
                                Health = p.Health - 10.0M
                            })
                            .ToList();

                            trainer.Pokemons = trainer.Pokemons.Where(p => !(p.Health <= 0.0M)).ToList(); 
                        }
                    }
                }
            }

            trainers = trainers.OrderByDescending(t => t.NumberOfBadges).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, trainers));
        }
    }
}
