using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class WardRobe
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> allClothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!allClothes.ContainsKey(color))
                {
                    allClothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!allClothes[color].ContainsKey(item))
                    {
                        allClothes[color].Add(item, 0);
                    }

                    allClothes[color][item]++;
                }
            }

            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            bool isInside = false;
            string wantedColor = tokens[0];
            string wantedItem = tokens[1];

            if (allClothes.ContainsKey(wantedColor))
            {
                if (allClothes[wantedColor].ContainsKey(wantedItem))
                {
                    isInside = true;
                }
            }

            var result = allClothes;//.OrderByDescending(a => a.Value.Count).ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var subDict in item.Value)
                {
                    if (item.Key == wantedColor && subDict.Key == wantedItem)
                    {
                        Console.WriteLine($"* {subDict.Key} - {subDict.Value} (found!)");

                    }
                    else
                    {
                        Console.WriteLine($"* {subDict.Key} - {subDict.Value}");
                    }

                }
            }

        }
    }
}
