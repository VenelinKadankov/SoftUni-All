using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowWhiteObjects
{
    class SnowObjects
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfs = new List<Dwarf>();
            string command = Console.ReadLine();


            while (command != "Once upon a time")
            {
                string[] tokens = command.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0], color = tokens[1];
                int points = int.Parse(tokens[2]);
                Dwarf someOne = new Dwarf(name, color, points);

                if (dwarfs.Count == 0)
                {
                    dwarfs.Add(someOne);
                }
                else
                {
                    for (int i = 0; i < dwarfs.Count; i++)
                    {
                        Dwarf current = dwarfs[i];

                            if (current.Name == someOne.Name && current.Color == someOne.Color)
                            {
                                if (current.Points < someOne.Points)
                                {
                                    current.Points = points;
                                    break;
                                }
                            }
                            else
                            {
                                dwarfs.Add(someOne);
                                break;
                            }

                    }
                }

                command = Console.ReadLine();
            }

            var result = dwarfs.OrderByDescending(a => a.Points).ThenByDescending(x => x.Color.Count()).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"({item.Color}) {item.Name} <-> {item.Points}");
            }

        }
    }

    class Dwarf
    {
        public Dwarf(string name, string color, int points)
        {
            Name = name;
            Color = color;
            Points = points;
        }


        public string Name { get; set; }
        public string Color { get; set; }
        public int Points { get; set; }
    }

}

