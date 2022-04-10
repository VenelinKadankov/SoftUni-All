using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        class Vloger
        {
            public Vloger(string name)
            {
                Name = name;
                Followers = new HashSet<string>();
                Following = new HashSet<string>();
            }

            public string Name { get; set; }
            public HashSet<string> Followers { get; set; }

            public HashSet<string> Following { get; set; }
        }
        static void Main(string[] args)
        {
            HashSet<Vloger> vlogers = new HashSet<Vloger>();
            HashSet<string> network = new HashSet<string>();

            string command = Console.ReadLine();

            while (command?.ToUpper() != "STATISTICS")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string nameV = tokens[0];
                string action = tokens[1];
                string secondName = tokens[2];

                if (action == "joined")
                {
                    if (!network.Contains(nameV))
                    {
                        network.Add(nameV);
                        Vloger current = new Vloger(nameV);
                        vlogers.Add(current);
                    }
                }
                else if (action == "followed")
                {
                    if (nameV != secondName && network.Contains(nameV) && network.Contains(secondName))
                    {
                        foreach (var vloger in vlogers)
                        {
                            if (vloger.Name == secondName && !vloger.Followers.Contains(nameV))
                            {
                                vloger.Followers.Add(nameV);
                            }

                            if (vloger.Name == nameV && !vloger.Following.Contains(secondName))
                            {
                                vloger.Following.Add(secondName);
                            }
                        }
                    }
                }


                command = Console.ReadLine();
            }

            vlogers = vlogers.OrderByDescending(a => a.Followers.Count).ThenBy(a => a.Following.Count).ToHashSet();
            int counter = 0;

            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");

            foreach (var item in vlogers)
            {
                counter++;
                Console.WriteLine($"{counter}. {item.Name} : {item.Followers.Count} followers, {item.Following.Count} following");
                if (counter == 1 && item.Followers.Count > 0)
                {
                    var listFollowers = item.Followers.OrderBy(a => a).ToArray();
                    foreach (var follower in listFollowers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

            }
        }
    }
}
