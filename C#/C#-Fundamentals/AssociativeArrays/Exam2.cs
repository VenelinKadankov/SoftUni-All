using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam2
{
    class Exam2
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> submisions = new Dictionary<string, int>();
            string command = Console.ReadLine();

            while (command != "exam finished")
            {
                string[] tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0], language = tokens[1];
                bool isBanned = false;
                int points = 0;

                if (tokens.Length > 2)
                {
                    points = int.Parse(tokens[2]);
                }
                else
                {
                    isBanned = true;
                }

                if (students.ContainsKey(name) && !isBanned)
                {
                    if (students[name] < points)
                    {
                        students[name] = points;
                    }

                    
                }
                else if (!students.ContainsKey(name) && !isBanned)
                {
                    students.Add(name, points);
                }

                if (submisions.ContainsKey(language) && !isBanned)
                {
                    submisions[language]++;
                }
                else if (!submisions.ContainsKey(language) && !isBanned)
                {
                    submisions.Add(language, 1);
                }

                if (isBanned)
                {
                    students.Remove(name);
                }

                command = Console.ReadLine();
            }

            var result = students.OrderByDescending(a => a.Value)
                .ThenBy(b => b.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            var subs = submisions.OrderByDescending(x => x.Value)
                .ThenBy(y => y.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            Console.WriteLine("Results:");
            foreach (var item in result)
            {
                Console.WriteLine(item.Key + " | " + item.Value);
            }

            Console.WriteLine("Submissions:");
            foreach (var item in subs)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
}
