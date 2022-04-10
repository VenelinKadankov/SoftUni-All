using System;
using System.Collections.Generic;
using System.Linq;

namespace _4_SnowWhite
{

    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Dwarf> dwarfs = new List<Dwarf>();

            while (command != "Once upon a time")
            {
                string[] tokens = command.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                string color = tokens[1];
                int physics = int.Parse(tokens[2]);
                Dwarf dwarf = new Dwarf(name, color, physics);
                bool isMatched = false;

                for (int i = 0; i < dwarfs.Count; i++)
                {

                    if (dwarfs[i].Name == name)
                    {

                        isMatched = true;

                        if (dwarfs[i].Color != color)
                        {
                            dwarfs.Add(dwarf);
                        }
                        else
                        {

                            if (dwarfs[i].Physics < physics)
                            {
                                dwarfs[i].Physics = physics;
                            }

                        }

                        break;
                    }

                }

                if (!isMatched)
                {
                    dwarfs.Add(dwarf);
                }

                command = Console.ReadLine();

            }

            Dictionary<string, int> colors = new Dictionary<string, int>();

            for (int i = 0; i < dwarfs.Count; i++)
            {

                if (!colors.ContainsKey(dwarfs[i].Color))
                {
                    colors.Add(dwarfs[i].Color, 0);
                }

                colors[dwarfs[i].Color]++;
            }

            colors = colors.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<Dwarf> sortedDwarfs = new List<Dwarf>();

            foreach (var color in colors.Keys)
            {

                for (int i = 0; i < dwarfs.Count; i++)
                {

                    if (dwarfs[i].Color == color)
                    {
                        sortedDwarfs.Add(dwarfs[i]);
                    }

                }

            }

            sortedDwarfs = sortedDwarfs.OrderByDescending(x => x.Physics).ToList();

            foreach (var item in sortedDwarfs)
            {
                Console.WriteLine($"({item.Color}) {item.Name} <-> {item.Physics}");
            }


        }

        class Dwarf
        {
            public Dwarf(string name, string color, int physics)
            {
                Name = name;
                Color = color;
                Physics = physics;
            }

            public string Name { get; set; }
            public string Color { get; set; }
            public int Physics { get; set; }

        }
    }
}
