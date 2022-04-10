using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> players = new Dictionary<string, List<int>>();
            string command = Console.ReadLine();


            while (command?.ToUpper() != "RESULTS")
            {
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string firstName = tokens[1];

                if (action?.ToUpper() == "ADD")
                {
                    int health = int.Parse(tokens[2]);
                    int energy = int.Parse(tokens[3]);

                    if (!players.ContainsKey(firstName))
                    {
                        players.Add(firstName, new List<int>());
                        players[firstName].Add(health);
                        players[firstName].Add(energy);
                    }
                    else
                    {
                        players[firstName][0] += health;
                        //players[firstName][1] += energy;
                    }
                    
                }
                else if (action?.ToUpper() == "ATTACK")
                {
                    string defender = tokens[2];
                    int damage = int.Parse(tokens[3]);

                    if (players.ContainsKey(firstName) && players.ContainsKey(defender))
                    {
                        players[defender][0] -= damage;

                        if (players[defender][0] <= 0)
                        {
                            players.Remove(defender);
                            Console.WriteLine($"{defender} was disqualified!");
                        }

                        players[firstName][1] -= 1;

                        if (players[firstName][1] <= 0)
                        {
                            players.Remove(firstName);
                            Console.WriteLine($"{firstName} was disqualified!");
                        }

                    }
                }
                else if (action?.ToUpper() == "DELETE")
                {

                    if (firstName?.ToUpper() == "ALL")
                    {
                        players = new Dictionary<string, List<int>>();
                    }
                    else if(players.ContainsKey(firstName))
                    {
                        players.Remove(firstName);
                    }
                }


                command = Console.ReadLine();
            }

            var result = players.OrderByDescending(a => a.Value[0])
                .ThenBy(a => a.Key)
                .ToDictionary(a => a.Key, a => a.Value);



            if (result.Count > 0)
            {
                Console.WriteLine($"People count: {result.Count}");
            }
            foreach (var player in result)
            {
                Console.WriteLine($"{player.Key} - {player.Value[0]} - {player.Value[1]}");
            }
        }
    }
}
