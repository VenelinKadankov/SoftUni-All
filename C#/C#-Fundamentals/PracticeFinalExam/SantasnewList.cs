using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasNewList
{
    class SantasnewList
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> kids = new Dictionary<string, int>();
            Dictionary<string, int> toys = new Dictionary<string, int>();

            string command = Console.ReadLine();

            while (command?.ToUpper() != "END")
            {
                string[] tokens = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0], toy = tokens[1];
                int amount = 0;

                if (tokens.Length > 2)
                {
                    amount = int.Parse(tokens[2]);
                }

                if (tokens[0]?.ToUpper() == "REMOVE")
                {
                    kids.Remove(tokens[1]);
                }
                else
                {

                    if (!kids.ContainsKey(name))
                    {
                        kids.Add(name, 0);

                    }

                    kids[name] += amount;

                    if (!toys.ContainsKey(toy))
                    {
                        toys.Add(toy, 0);
                    }

                    toys[toy] += amount;
                }
                command = Console.ReadLine();
            }

            var sortedKids = kids.OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            Console.WriteLine("Children:");

            foreach (var item in sortedKids)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            Console.WriteLine("Presents:");

            foreach (var item in toys)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
