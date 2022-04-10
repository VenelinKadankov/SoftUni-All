
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class SoftuniCoursePlanning
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command.ToLower() != "course start")
            {
                string[] actions = command.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = actions[0], title = actions[1];

                if (action.ToLower() == "add")
                {
                    if (!schedule.Contains(title))
                    {
                        schedule.Add(title);
                    }

                }
                else if (action.ToLower() == "insert")
                {
                    int index = int.Parse(actions[2]);

                    if (!schedule.Contains(title))
                    {
                        schedule.Insert(index, title);
                    }

                }
                else if (action.ToLower() == "remove")
                {
                    if (schedule.Contains(title))
                    {
                       
                        if (schedule.Contains($"{title}-Exercise"))
                        {
                            schedule.Remove($"{title}-Exercise");
                            schedule.Remove(title);
                        }
                        else
                        {
                            schedule.Remove(title);
                        }
                    }

                }
                else if (action.ToLower() == "swap")
                {
                    string title2 = actions[2];

                    if (schedule.Contains(title) && schedule.Contains(title2))
                    {
                        int firstIndex = schedule.IndexOf(title);
                        int secondIndex = schedule.IndexOf(title2);

                        schedule[firstIndex] = title2;
                        schedule[secondIndex] = title;

                        if (schedule.Contains($"{title}-Exercise"))
                        {
                            schedule.Remove($"{title}-Exercise");
                            schedule.Insert(schedule.IndexOf(title) + 1, $"{title}-Exercise");
                        }

                        if (schedule.Contains($"{title2}-Exercise"))
                        {
                            schedule.Remove($"{title2}-Exercise");
                            schedule.Insert(schedule.IndexOf(title2) + 1, $"{title2}-Exercise");
                        }
                       
                    }

                }
                else if (action.ToLower() == "exercise")
                {

                    if (!schedule.Contains(title) && !schedule.Contains($"{title}-Exercise"))
                    {
                        schedule.Add(title);
                        schedule.Add($"{title}-Exercise");
                    }
                    else if (!schedule.Contains($"{title}-Exercise"))
                    {
                        schedule.Insert(schedule.IndexOf(title) + 1, $"{title}-Exercise");
                    }

                }

                command = Console.ReadLine();
            }


            int i = 1;
            foreach (var item in schedule)
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }
        }
    }
}


