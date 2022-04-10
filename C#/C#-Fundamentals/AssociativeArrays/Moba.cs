using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallanger
{
    class Moba
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();

            while (command?.ToLower() != "season end")
            {
                string player = string.Empty, position = string.Empty, oponent = string.Empty;
                int points = 0;

                if (command.Contains("->"))
                {
                    string[] tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    player = tokens[0];
                    position = tokens[1];
                    points = int.Parse(tokens[2]);

                    if (players.ContainsKey(player))
                    {
                        if (players[player].ContainsKey(position))
                        {
                            if (players[player][position] < points)
                            {
                                players[player][position] = points;
                            }
                        }
                        else
                        {
                            players[player].Add(position, points);
                        }
                    }
                    else
                    {
                        players.Add(player, new Dictionary<string, int>());
                        players[player].Add(position, points);
                    }

                }
                else
                {
                    string[] tokens = command.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                    player = tokens[0];
                    oponent = tokens[1];
                    bool isMatching = false;


                    if (players.ContainsKey(player) && players.ContainsKey(oponent))
                    {
                        foreach (var item in players[player])
                        {
                            string current = item.Key;

                            string arena = string.Empty;


                            foreach (var line in players[oponent])
                            {
                                if (line.Key == item.Key)
                                {
                                    isMatching = true;
                                    break;
                                }

                            }

                            if (isMatching)
                            {
                                break;
                            }

                            if (isMatching)
                            {
                                break;
                            }
                        }
                    }

                    if (isMatching)
                    {
                        int firstPoints = players[player].Values.Sum();
                        int secondPoints = players[oponent].Values.Sum();

                        if (firstPoints > secondPoints)
                        {
                            players.Remove(oponent);
                        }
                        else if (secondPoints > firstPoints)
                        {
                            players.Remove(player);
                        }
                    }

                }


                command = Console.ReadLine();
            }

            Dictionary<string, int> playersByPoints = new Dictionary<string, int>();

            foreach (var item in players)
            {
                string name = item.Key;
                int points = item.Value.Values.Sum();

                playersByPoints.Add(name, points);
            }

            var res = playersByPoints.OrderByDescending(a => a.Value)
                .ThenBy(b => b.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            var result = players.OrderByDescending(a => a.Value.Values.Sum())
                .ThenBy(b => b.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in result)
            {


                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");

                Dictionary<string, int> current = item.Value.OrderByDescending(b => b.Value)
                    .ThenBy(a => a.Key)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (var line in current)
                {
                    Console.WriteLine($" - {line.Key} <::> {line.Value}");
                }


            }
        }
    }
}
