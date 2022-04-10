using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    class Pirates
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, List<int>> towns = new Dictionary<string, List<int>>();

            while (command?.ToLower() != "sail")
            {
                string[] tokens = command.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int population = int.Parse(tokens[1]), gold = int.Parse(tokens[2]);

                if (!towns.ContainsKey(name)) 
                {
                    towns.Add(name, new List<int>());
                    towns[name].Add(population);
                    towns[name].Add(gold);
                }
                else
                {
                    towns[name][0] += population;
                    towns[name][1] += gold;
                }

                command = Console.ReadLine();
            }

            string action = Console.ReadLine();

            while (action?.ToLower() != "end")
            {
                string[] tokens = action.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string act = tokens[0];

                if (act?.ToLower() == "plunder")
                {
                    string town = tokens[1];
                    int people = int.Parse(tokens[2]), gold = int.Parse(tokens[3]);

                    if (towns.ContainsKey(town))
                    {
                        towns[town][0] -= people;
                        towns[town][1] -= gold;

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (towns[town][0] <= 0 || towns[town][1] <= 0)
                        {
                            towns.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                    }
                }
                else
                {
                    string town = tokens[1];
                    int gold = int.Parse(tokens[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        if (towns.ContainsKey(town))
                        {
                            towns[town][1] += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town][1]} gold.");
                        }
                    }
                }


                action = Console.ReadLine();
            }

            var townsLeft = towns
                .OrderByDescending(a => a.Value[1])
                .ThenBy(a => a.Key)
                .ToDictionary(b => b.Key, b => b.Value);

            if (townsLeft.Count != 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townsLeft.Count} wealthy settlements to go to:");

                foreach (var item in townsLeft)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
