using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Ranking
    {
        class Cand
        {
            public Cand(string subject, int points)
            {
                Subject = subject;
                Points = points;
            }

            public string Subject { get; set; }
            public int Points { get; set; }

        }
        static void Main(string[] args)
        {
            Dictionary<string, string> subjectsWithPasses = new Dictionary<string, string>();
            Dictionary<string, List<Cand>> candidates = new Dictionary<string, List<Cand>>();

            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string subject = tokens[0];
                string pass = tokens[1];

                if (!subjectsWithPasses.ContainsKey(subject))
                {
                    subjectsWithPasses.Add(subject, pass);
                }

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

                if (subjectsWithPasses.ContainsKey(subject) && subjectsWithPasses[subject] == pass)
                {
                    if (!candidates.ContainsKey(name))
                    {
                        candidates.Add(name, new List<Cand>());
                        candidates[name].Add(new Cand(subject, points));
                    }
                    else
                    {
                        bool subjectIsIncluded = false;
                        foreach (var item in candidates[name])
                        {
                            if (item.Subject == subject && item.Points < points)
                            {
                                item.Points = points;
                            }
                            else if (item.Subject == subject)
                            {
                                subjectIsIncluded = true;
                            }
                        }

                        if (!subjectIsIncluded)
                        {
                            candidates[name].Add(new Cand(subject, points));
                        }

                    }
                }


                line = Console.ReadLine();
            }

            int maxPoints = 0;
            string maxName = string.Empty;

            foreach (var item in candidates)
            {
                int sum = 0;
                foreach (var subj in item.Value)
                {
                    sum += subj.Points;
                }

                if (maxPoints < sum)
                {
                    maxPoints = sum;
                    maxName = item.Key;
                }
            }

            candidates = candidates.OrderBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);

            Console.WriteLine($"Best candidate is {maxName} with total {maxPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var candidate in candidates)
            {
                Console.WriteLine($"{candidate.Key}");
                var result = candidate.Value.OrderByDescending(a => a.Points).ToList();
                foreach (var subjPoints in result)
                {
                    Console.WriteLine($"#  {subjPoints.Subject} -> {subjPoints.Points}");
                }
            }
        }
    }
}
