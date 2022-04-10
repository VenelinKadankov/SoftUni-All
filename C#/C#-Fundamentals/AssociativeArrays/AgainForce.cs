using System;
using System.Collections.Generic;
using System.Linq;

namespace AgainForce
{
    class AgainForce
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                string specialSymbol = string.Empty;
                string name, team;

                if (command.Contains(" | "))
                {
                    string[] arr = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    name = arr[1];
                    team = arr[0];
                    specialSymbol = " | ";

                    if (users.ContainsKey(team))
                    {

                        if (!users[team].Contains(name))
                        {
                            users[team].Add(name);
                        }
                    }
                    else 
                    {
                        users.Add(team, new List<string>());
                        users[team].Add(name);
                    }

                }
                else if(command.Contains(" -> "))
                {
                    string[] arr = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    name = arr[0];
                    team = arr[1];
                    specialSymbol = " -> ";

                    bool isIncluded = false;
                    string wantedGroup = string.Empty;

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

                        if (users.ContainsKey(team))
                        {
                            users[team].Add(name);
                        }
                        else
                        {
                            users.Add(team, new List<string>());
                            users[team].Add(name);
                        }

                        
                    }
                    else
                    {
                        if (users.ContainsKey(team))
                        {
                            users[team].Add(name);
                        }
                        else
                        {
                            users.Add(team, new List<string>());
                            users[team].Add(name);
                        }
                    }

                    Console.WriteLine($"{name} joins the {team} side!");
                }


                command = Console.ReadLine();
            }

            var result = users.OrderByDescending(a => a.Value.Count).ThenBy(b => b.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in result)
            {

                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                    var res = item.Value.OrderBy(a => a).ToList();

                    foreach (var name in res)
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }
        }
    }
}
