using System;
using System.Collections.Generic;
using System.Linq;


namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> subj = new Dictionary<string, string>();
            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] arr = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = arr[0];
                string password = arr[1];

                if (!subj.ContainsKey(contest))
                {
                    subj.Add(contest, password);
                }

                command = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();

            while (line != "end of submissions")
            {
                string[] tokens = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0], pass = tokens[1], name = tokens[2];
                int points = int.Parse(tokens[3]);

                if (subj.ContainsKey(contest))
                {

                    if (subj[contest] == pass)
                    {

                        if (!candidates.ContainsKey(name))
                        {
                            candidates.Add(name, new Dictionary<string, int>());
                            candidates[name].Add(contest, points);
                        }
                        else
                        {
                            if (!candidates[name].ContainsKey(contest))
                            {
                                candidates[name].Add(contest, points);
                            }
                            else
                            {
                                if (candidates[name][contest] < points)
                                {
                                    candidates[name][contest] = points;
                                }
                            }
                        }


                    }

                }



                line = Console.ReadLine();
            }

            int maxPoints = 0;
            string bestName = string.Empty;

            foreach (var item in candidates)
            {
                int points = 0;

                foreach (var cont in item.Value)
                {
                    points += cont.Value;
                }

                if (points > maxPoints)
                {
                    maxPoints = points;
                    bestName = item.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestName} with total {maxPoints} points.");
            Console.WriteLine("Ranking: ");

            var result = candidates.OrderBy(a => a.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in result)
            {
                Console.WriteLine(item.Key);

                var res = item.Value.OrderByDescending(a => a.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (var thing in res)
                {
                    Console.WriteLine($"#  {thing.Key} -> {thing.Value}");
                }
            }
        }
    }
}
