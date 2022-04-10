using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class PokemonTrainer
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string command = Console.ReadLine();

            while (command?.ToUpper() != "TOURNAMENT")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string powerType = tokens[2];
                int health = int.Parse(tokens[3]);

                if (!trainers.Any(a => a.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName, pokemonName, powerType, health));
                }
                else
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Name == trainerName)
                        {
                            trainer.PokemonList.Add(new Pokemon(pokemonName, powerType, health));
                        }
                    }
                }

                command = Console.ReadLine();
            }

            string line = Console.ReadLine();

            while (line?.ToUpper() != "END")
            {

                foreach (var trainer in trainers)
                {
                    if (trainer.PokemonList.Any(a => a.Element == line))
                    {
                        trainer.NumberBadges++;
                    }
                    else
                    {
                        trainer.PokemonList.Select(a => a.Health -= 10).ToList();
                        trainer.PokemonList = trainer.PokemonList.Where(a => a.Health > 0).ToList();
                    }
                }

                line = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(a => a.NumberBadges).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberBadges} {trainer.PokemonList.Count}");
            }
        }
    }
}
