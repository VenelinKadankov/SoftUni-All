using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> force = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command?.ToLower() != "lumpawaroo")
            {

                if (command.Contains(" | "))
                {
                    string[] info = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = info[0];
                    string name = info[1];

                    if (force.ContainsKey(side) && !force[side].Contains(name))
                    {
                        force[side].Add(name);
                    }
                    else if(!force.ContainsKey(side))
                    {
                        force.Add(side, new List<string>());
                        force[side].Add(name);
                    }

                }
                else if (command.Contains(" -> "))
                {
                    string[] info = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string side = info[1];
                    string name = info[0];

                    bool isInside = false;
                    string oldSide = string.Empty;

                    foreach (var item in force)
                    {
                        if (item.Value.Contains(name))// && force.Keys.Contains(side))
                        {
                            isInside = true;
                            oldSide = item.Key;
                        }
                    }

                    if (isInside)
                    {
                        force[oldSide].Remove(name);
                        force[side].Add(name);

                    }
                    else
                    {
                        if (force.ContainsKey(side))
                        {
                            force[side].Add(name);
                        }
                        else
                        {
                            force.Add(side, new List<string>());
                            force[side].Add(name);
                        }
                    }

                    if (command.Contains(" -> "))
                  //  {
                        Console.WriteLine($"{name} joins the {side} side!");
                    //}
                }

                command = Console.ReadLine();
            }

            Dictionary<string, List<string>> result = force.OrderByDescending(a => a.Value.Count)
                                                           .ThenBy(b => b.Key)
                                                           .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in result)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    string[] users = item.Value.OrderBy(a => a).ToArray();

                    foreach (var user in users)
                    {
                        Console.WriteLine($"! {user}");
                    }

                }

            }
        }
    }
}
