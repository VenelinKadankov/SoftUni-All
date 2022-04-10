using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            //Dictionary<string, Dictionary<string, List<int>>> dragons = new Dictionary<string, Dictionary<string, List<int>>>();
            int n = int.Parse(Console.ReadLine());
            List<Dragon> allDragons = new List<Dragon>(n);
            Dictionary<string, int> colors = new Dictionary<string, int>();



            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0], name = tokens[1];
                int damage = 45, health = 250, armour = 10;

                if (tokens[2] != "null")
                {
                    damage = int.Parse(tokens[2]);
                }

                if (tokens[3] != "null")
                {
                    health = int.Parse(tokens[3]);
                }

                if (tokens[4] != "null")
                {
                    armour = int.Parse(tokens[4]);
                }

                Dragon created = new Dragon(name, color, damage, health, armour);

                if (allDragons.Count == 0)
                {
                    allDragons.Add(created);
                }
                else
                {

                    bool isIncluded = false;
                    int index = 0;

                    for (int k = 0; k < allDragons.Count; k++)
                    {
                        var compared = allDragons[k];

                        if (compared.Name == created.Name && compared.Color == created.Color)
                        {
                            isIncluded = true;
                            index = k;
                            break;
                        }

                    }

                    if (isIncluded)
                    {
                        allDragons[index].Damage = created.Damage;
                        allDragons[index].Health = created.Health;
                        allDragons[index].Armour = created.Armour;                        
                    }
                    else
                    {
                        allDragons.Add(created);                     
                    }

                }

            }

            Dictionary<string, int> types = new Dictionary<string, int>();

            for (int i = 0; i < allDragons.Count; i++)
            {
                Dragon current = allDragons[i];

                if (types.ContainsKey(current.Color))
                {
                    types[current.Color]++;
                }
                else
                {
                    types.Add(current.Color, 1);
                }
            }

            var orderedTypes = types.OrderByDescending(a => a.Value).ThenBy(b => b.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            Dictionary<string, Dictionary<string, List<int>>> dragonDictionary = new Dictionary<string, Dictionary<string, List<int>>>();

            foreach (var item in types)
            {
                if (!dragonDictionary.ContainsKey(item.Key))
                {
                    dragonDictionary.Add(item.Key, new Dictionary<string, List<int>>());
                }
            }


            for (int i = 0; i < allDragons.Count; i++)
            {
                string nam = allDragons[i].Name, col = allDragons[i].Color;
                int dam = allDragons[i].Damage, hel = allDragons[i].Health, arm = allDragons[i].Armour;
                List<int> currentDragon = new List<int>();
                currentDragon.Add(dam);
                currentDragon.Add(hel);
                currentDragon.Add(arm);

                dragonDictionary[col].Add(nam, currentDragon);

            }

            foreach (var item in dragonDictionary)
            {
                var current = item.Value.OrderBy(a => a.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

                double averageDmg = 0.0, averageHel = 0.0, averageArm = 0.0;
                int length = 0;

                foreach (var dr in current)
                {
                    averageDmg += dr.Value[0];
                    averageHel += dr.Value[1];
                    averageArm += dr.Value[2];
                    length++;
                }

                averageArm /= length;
                averageDmg /= length;
                averageHel /= length;

                Console.WriteLine($"{item.Key}::({averageDmg:F2}/{averageHel:F2}/{averageArm:F2})");

                foreach (var line in current)
                {
                    Console.WriteLine($"-{line.Key} -> damage: {line.Value[0]}, health: {line.Value[1]}, armor: {line.Value[2]}");
                }
            }

        }
    }

    class Dragon
    {
        public Dragon(string name, string color, int damage, int health, int armour)
        {
            Name = name;
            Color = color;
            Damage = damage;
            Health = health;
            Armour = armour;
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armour { get; set; }
    }
}
