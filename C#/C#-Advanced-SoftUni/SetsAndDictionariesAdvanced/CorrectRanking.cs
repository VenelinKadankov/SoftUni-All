using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            HashSet<string> subjectsWithPasses = new HashSet<string>();
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                subjectsWithPasses.Add(command);
                command = Console.ReadLine();
            }

            string line = Console.ReadLine();

            while (line != "end of submissions")
            {
                string[] tokens = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string subject = tokens[0];
                string pass = tokens[1];
                string name = tokens[2];
                int points = int.Parse(tokens[3]);
                string[] arr = new string[] { subject, pass };
                string checking = string.Join(":", arr);

                if (subjectsWithPasses.Contains(checking))
                {
                    if (!candidates.ContainsKey(name))
                    {
                        candidates.Add(name, new Dictionary<string, int>());
                        candidates[name].Add(subject, points);
                    }
                    else
                    {
                        if (!candidates[name].ContainsKey(subject))
                        {
                            candidates[name].Add(subject, points);
                        }

                        if (candidates[name][subject] < points)
                        {
                            candidates[name][subject] = points;
                        }

                    }
                }


                line = Console.ReadLine();
            }

            int maxPoints = 0;
            string maxName = string.Empty;

            foreach (var candidate in candidates)
            {
                int sum = 0;

                foreach (var subj in candidate.Value)
                {
                    sum += subj.Value;
                }

                if (sum > maxPoints)
                {
                    maxPoints = sum;
                    maxName = candidate.Key;
                }
            }

            candidates = candidates.OrderBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);

            Console.WriteLine($"Best candidate is {maxName} with total {maxPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var candidate in candidates)
            {
                Console.WriteLine($"{candidate.Key}");
                var result = candidate.Value.OrderByDescending(a => a.Value).ToList();
                foreach (var subjPoints in result)
                {
                    Console.WriteLine($"#  {subjPoints.Key} -> {subjPoints.Value}");
                }
            }
        }
    }
}
