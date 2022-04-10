using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class ExamResults
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> counter = new Dictionary<string, int>();
            string command = Console.ReadLine();

            while (command != "exam finished")
            {
                List<string> tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = tokens[0], language = tokens[1];
                int points = 0;
                bool isBanned = false;

                if (tokens.Count > 2)
                {
                    points = int.Parse(tokens[2]);
                }
                else
                {
                    isBanned = true;
                }

                if (isBanned)
                {
                    Console.WriteLine(name + " ->  banned");
                    var list = students.Select(a => a.Value).Where(b => b.ContainsKey(name)).ToList();

                    for (int i = 0; i < students.Count; i++)
                    {
                        Dictionary<string, int> current = students.ElementAt(i).Value;

                        if (current.ContainsKey(name))
                        {
                            current.Remove(name);
                        }
                       // Console.WriteLine(string.Join("....", current));
                    }

                    int n = list.Count;



                    isBanned = false;
                }

                else if (students.ContainsKey(language) && language != "banned")
                {

                    if (students[language].ContainsKey(name) && students[language][name] < points)
                    {
                        students[language][name] = points;
                    }
                    else
                    {
                        students[language].Add(name, points);
                    }

                    counter[language]++;

                } 
                else if (!students.ContainsKey(language) && language != "banned")
                {
                    students.Add(language, new Dictionary<string, int>());
                    students[language].Add(name, points);

                    counter.Add(language, 1);
                }
                


                command = Console.ReadLine();
            }

            for (int i = 0; i < students.Count; i++)
            {
                int current = students.ElementAt(i).Value.Max(a => a.Value);
                Console.WriteLine(current);
            }

            foreach (var item in students)
            {
                Console.WriteLine(item.Key + "----" + string.Join("", item.Value));
            }
        }
    }
}
