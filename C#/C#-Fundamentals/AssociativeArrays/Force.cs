using System;
using System.Collections.Generic;
using System.Linq;

namespace AgainForceBook
{
    class Force
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                string[] tokens = new string[2];
                string symbol = string.Empty;

                if (command.Contains(" | "))
                {

                    string[] tokens2 = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    tokens = tokens2;
                    symbol = " | ";

                }
                else if (command.Contains(" -> "))
                {
                    string[] tokens2 = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
                    tokens = tokens2;
                    symbol = " -> ";
                }

                string side = tokens[0], name = tokens[1];

                if (users.ContainsKey(side) && symbol == " | ")
                {
                    if (!users[side].Contains(name))
                    {
                        var searched = users.Select(a => a.Value).Where(x => x.Contains(name)).ToList();
                        searched[0].Remove(name);
                        users[side].Add(name);

                    }
                }
                else if (!users.ContainsKey(side) && symbol == " | ")
                {
                    users.Add(side, new List<string>());
                    users[side].Add(name);                     // тук може да се проведи дали съдържа името да няма повторения
                }
                else if (symbol == " -> ")
                {
                    string wantedGroup = string.Empty;
                    bool isIncluded = false;

                    foreach (var item in users)
                    {
                        if (item.Value.Contains(name))
                        {
                            wantedGroup = item.Key;
                            isIncluded = true;
                        }
                    }

                    if (isIncluded)
                    {

                        var searched = users.Select(a => a.Value).Where(x => x.Contains(name)).ToList();
                        searched[0].Remove(name);

                        if (users.ContainsKey(side))
                        {
                            users[side].Add(name);
                        }
                        else
                        {
                            users.Add(side, new List<string>());
                            users[side].Add(name);
                        }

                       // Console.WriteLine($"{name} joins the {side} side!");
                    }

                    else
                    {

                        if (users.ContainsKey(side))
                        {
                            users[side].Add(name);
                        }
                        else
                        {
                            users.Add(side, new List<string>());
                            users[side].Add(name);
                        }

                        Console.WriteLine($"{name} joins the {side} side!");

                    }

                    //Console.WriteLine($"{name} joins the {side} side!");

                }

                command = Console.ReadLine();
            }

            var result = users.OrderByDescending(a => a.Value.Count).ThenBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in result)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                    List<string> names = item.Value.OrderBy(a => a).ToList();

                    foreach (var name in names)
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }
        }
    }
}
