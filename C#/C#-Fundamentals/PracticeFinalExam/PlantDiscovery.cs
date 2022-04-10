using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PLantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> plants = new Dictionary<string, List<int>>();
            string pattern = @"[A-Z][a-z]+: [a-zA-Z]+ ?-? ?{?\d*}??";
            Regex regex = new Regex(pattern);


            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = line[0];
                int points = int.Parse(line[1]);

                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new List<int>());
                    plants[plant].Add(points);
                }
                else
                {
                    plants[plant][0] = points;
                }


            }

            string command = Console.ReadLine();

            while (command?.ToLower() != "exhibition")
            {
                if (regex.IsMatch(command))
                {
                    string[] tokens = command.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                    string action = tokens[0], left = tokens[1];
                    string[] parts = left.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string name = parts[0];





                    if (action?.ToLower() == "rate")
                    {
                        int points = int.Parse(parts[1]);

                        if (plants.ContainsKey(name))
                        {
                            plants[name].Add(points);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                    }
                    else if (action?.ToLower() == "update")
                    {
                        int points = int.Parse(parts[1]);

                        if (plants.ContainsKey(name))
                        {
                            plants[name][0] = points;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }

                    }
                    else if (action?.ToLower() == "reset")
                    {
                        if (plants.ContainsKey(name))
                        {
                            int rarity = plants[name][0];
                            plants[name] = new List<int>();
                            plants[name].Add(rarity);
                            //plants[name].Add(0);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else
                {
                    Console.WriteLine("error");
                }

                command = Console.ReadLine();
            }

            var result = new Dictionary<string, List<double>>();

            foreach (var item in plants)
            {
                double average = 0.0;
                double sum = 0.0;
                int counter = 0;

                if (item.Value.Count > 1)
                {
                    foreach (var number in item.Value.Skip(1))
                    {
                        sum += (double)number;
                        counter++;
                    }

                    average = sum / (double)counter;

                }

                if (!result.ContainsKey(item.Key))
                {
                    result.Add(item.Key, new List<double>());
                }

                result[item.Key].Add((double)item.Value[0]);
                result[item.Key].Add(average);

            }

            result = result.OrderByDescending(a => a.Value[0]).ThenByDescending(a => a.Value[1]).ToDictionary(a => a.Key, a => a.Value);

            Console.WriteLine("Plants for the exhibition:");


            foreach (var item in result)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {Math.Round(item.Value[0])}; Rating: {item.Value[1]:F2}");
            }

        }
    }
}
