using System;
using System.Collections.Generic;
using System.Linq;

namespace AgainPlant
{
    class AgainPlant
    {
        class Plant
        {
            public Plant(string name, int rarity)
            {
                Name = name;
                Rarity = rarity;
                Rating = new List<double>();
            }

            public string Name { get; set; }
            public int Rarity { get; set; }
            public List<double> Rating { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                plants.Add(new Plant(line[0], int.Parse(line[1])));
            }

            string command = Console.ReadLine();
            string[] delimiters = { ": ", " - " };

            while (command != "Exhibition")
            {
                string[] tokens = command.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[1], action = tokens[0];

                if (action == "Rate")
                {
                    double rating = double.Parse(tokens[2]);

                    for (int i = 0; i < plants.Count; i++)
                    {
                        if (plants[i].Name == name)
                        {
                            plants[i].Rating.Add(rating);
                        }

                    }
                }
                else if (action == "Update")
                {
                    int rarity = int.Parse(tokens[2]);

                    for (int i = 0; i < plants.Count; i++)
                    {
                        if (plants[i].Name == name)
                        {
                            plants[i].Rarity = rarity;
                        }

                    }
                }
                else if (action == "Reset")
                {
                    for (int i = 0; i < plants.Count; i++)
                    {
                        if (plants[i].Name == name)
                        {
                            plants[i].Rating = new List<double>();
                            plants[i].Rating.Add(0);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < plants.Count; i++)
            {

                double average = plants[i].Rating.Average();
                plants[i].Rating = new List<double>();
                plants[i].Rating.Add(average);


            }

            var result = plants.OrderByDescending(a => a.Rarity).ThenByDescending(a => a.Rating[0]).ToList();

            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in result)
            {
                Console.WriteLine($"- {item.Name}; Rarity: {item.Rarity}; Rating: {item.Rating[0]:F2}");
            }
        }
    }
}
