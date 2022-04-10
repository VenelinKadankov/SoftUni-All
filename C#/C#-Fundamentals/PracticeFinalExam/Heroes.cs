using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogic
{
    class Heroes
    {
        static void Main(string[] args)
        {
            int countHeroes = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>(countHeroes);


            for (int i = 0; i < countHeroes; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = line[0];
                int hp = int.Parse(line[1]), mana = int.Parse(line[2]);

                if (!heroes.ContainsKey(name))
                {
                    heroes.Add(name, new List<int>());
                    heroes[name].Add(hp);
                    heroes[name].Add(mana);
                }
            }

            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                string[] tokens = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0], name = tokens[1];

                if (action?.ToLower() == "castspell")
                {
                    string spell = tokens[3];
                    int points = int.Parse(tokens[2]);

                    if (heroes[name][1] >= points)
                    {
                        heroes[name][1] -= points;
                        Console.WriteLine($"{name} has successfully cast {spell} and now has {heroes[name][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
                    }

                }
                else if (action?.ToLower() == "takedamage")
                {
                    string attacker = tokens[3];
                    int damage = int.Parse(tokens[2]);

                    if (heroes[name][0] > damage)
                    {
                        heroes[name][0] -= damage;
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name][0]} HP left!");
                    }
                    else
                    {
                        heroes.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }

                }
                else if (action?.ToLower() == "recharge")
                {
                    int amount = int.Parse(tokens[2]);

                    if (heroes[name][1] + amount > 200)
                    {
                        amount = 200 - heroes[name][1];
                    }

                    heroes[name][1] += amount;
                    Console.WriteLine($"{name} recharged for {amount} MP!");
                }
                else if (action?.ToLower() == "heal")
                {
                    int amount = int.Parse(tokens[2]);

                    if (heroes[name][0] + amount > 100)
                    {
                        amount = 100 - heroes[name][0];
                    }

                    heroes[name][0] += amount;
                    Console.WriteLine($"{name} healed for {amount} HP!");
                }

                command = Console.ReadLine();
            }

            var result = heroes.OrderByDescending(a => a.Value[0]).ThenBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine($"  HP: {item.Value[0]}");
                Console.WriteLine($"  MP: {item.Value[1]}");
            }
        }
    }
}
