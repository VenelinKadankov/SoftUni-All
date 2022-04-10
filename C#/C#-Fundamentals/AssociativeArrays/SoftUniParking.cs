using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class SoftUniParking
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> register = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0], name = tokens[1], plate = string.Empty;

                if (tokens.Length > 2)
                {
                    plate = tokens[2];
                }

                if (action?.ToLower() == "register")
                {

                    if (register.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plate}");
                    }
                    else
                    {
                        Console.WriteLine($"{name} registered {plate} successfully");
                        register.Add(name, plate);
                    }

                } 
                else if (action?.ToLower() == "unregister")
                {

                    if (register.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} unregistered successfully");
                        register.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }

            foreach (var item in register)
            {
                Console.WriteLine(item.Key + " => " + item.Value);
            }
        }
    }
}



