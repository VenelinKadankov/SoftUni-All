using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> items = new SortedDictionary<string, int>() ;
            items.Add("fragments", 0);
            items.Add("motes", 0);
            items.Add("shards", 0);
            SortedDictionary<string, int> unwanted = new SortedDictionary<string, int>();
            string reachedMaterial = string.Empty;

            while (items["fragments"] < 250 && items["motes"] < 250 && items["shards"] < 250)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    
                    int quantity = int.Parse(tokens[i]);
                    string material = tokens[i + 1].ToLower();

                    if (items.ContainsKey(material))
                    {
                        items[material] += quantity;

                        if (items[material] >= 250)
                        {
                            reachedMaterial = material;
                            break;
                        }
                    }
                    else
                    {
                        if (unwanted.ContainsKey(material))
                        {
                            unwanted[material] += quantity;
                        }
                        else
                        {
                            unwanted.Add(material, quantity);
                        }
                    }
                }


            }

            string result = string.Empty;

            if (reachedMaterial == "fragments")
            {
                result = "Valanyr";
                items[reachedMaterial] -= 250;
                Console.WriteLine($"{result} obtained!");
            }
            else if (reachedMaterial == "shards")
            {
                result = "Shadowmourne";
                items[reachedMaterial] -= 250;
                Console.WriteLine($"{result} obtained!");
            }
            else if (reachedMaterial == "motes")
            {
                result = "Dragonwrath";
                items[reachedMaterial] -= 250;
                Console.WriteLine($"{result} obtained!");
            }

            var ordered = items.OrderByDescending(a => a.Value).ThenBy(b => b.Key);

            foreach (var item in ordered)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }

            var orderdedUnwanted = unwanted.OrderBy(a => a.Key);

            foreach (var item in unwanted)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
