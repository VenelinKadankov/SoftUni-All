using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;

namespace Loot
{
    class Loot
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            double averageGain = 0.0;

            while (command != "Yohoho!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];

                if (action?.ToLower() == "loot")
                {

                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (!treasure.Contains(tokens[i]))
                        {
                            treasure.Insert(0, tokens[i]);
                        }
                    }

                }
                else if (action?.ToLower() == "drop")
                {
                    int index = int.Parse(tokens[1]);

                    if (0 <= index && index < treasure.Count)
                    {
                        string item = treasure[index];
                        treasure.RemoveAt(index);
                        treasure.Add(item);
                    }

                }
                else if (action?.ToLower() == "steal")
                {
                    int count = int.Parse(tokens[1]);

                    if (count > treasure.Count)
                    {
                        count = treasure.Count;
                    }

                    string[] stolen = treasure.GetRange(treasure.Count - count, count).ToArray();
                    treasure.RemoveRange(treasure.Count - count, count);
                    Console.WriteLine(string.Join(", ", stolen));
                }

                command = Console.ReadLine();
            }

            int totalLength = 0;

            foreach (var item in treasure)
            {
                totalLength += item.Length;
            }

            averageGain = (double)totalLength / treasure.Count;

            if (treasure.Count > 0)
            {
                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
            else
            { 
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
