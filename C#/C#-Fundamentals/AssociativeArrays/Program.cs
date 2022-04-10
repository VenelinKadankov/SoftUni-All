using System;
using System.Collections.Generic;
using System.Linq;

namespace AndAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                string name = string.Empty, side = string.Empty;

                if (command.Contains("|"))
                {
                    string[] arr = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    name = arr[1];
                    side = arr[0];

                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, side);
                    }

                }
                else
                {
                    string[] arr = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    name = arr[0];
                    side = arr[1];

                    if (users.ContainsKey(name))
                    {
                        users.Remove(name);
                        users.Add(name, side);
                    }
                    else
                    {
                        users.Add(name, side);
                    }

                    Console.WriteLine($"{name} joins the {side} side!");
                }
              
                command = Console.ReadLine();
            }

            var result = users.GroupBy(a => a.Value).OrderByDescending(b => b.Count()).ThenBy(c => c.Key);

            foreach (var item in result)
            {
                string teamName = item.Key;
                int teamCount = item.Count();

                Console.WriteLine($"Side: {teamName}, Members: {teamCount}");

                var names = item.OrderBy(x => x.Key);

                foreach (var name in names)
                {
                    Console.WriteLine($"! {name.Key}");
                }
            }

        }
    }
}
