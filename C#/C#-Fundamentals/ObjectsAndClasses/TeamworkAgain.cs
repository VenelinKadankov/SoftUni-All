using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkAgain
{
    class TeamworkAgain
    {
        static void Main(string[] args)
        {
            int countTeams = int.Parse(Console.ReadLine());
            List<Player> allTeams = new List<Player>(countTeams);
            List<string> teams = new List<string>();
            List<string> names = new List<string>();
            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                if (command.Contains("->"))
                {
                    string[] tokens = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
                    Player current = new Player(tokens[0], tokens[1]);

                    if (!teams.Contains(tokens[1]))
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist!");
                    }

                   else if (names.Contains(tokens[0]))
                    {
                        Console.WriteLine($"Member {tokens[0]} cannot join team {tokens[1]}!");
                    }
                    else
                    {
                        allTeams.Add(current);
                    }

                }
                else if (command.Contains("-"))
                {
                    string[] tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                    Player current = new Player(tokens[0], tokens[1]);

                    if (!teams.Contains(tokens[1]) && !names.Contains(tokens[0]))
                    {
                        teams.Add(tokens[1]);
                        names.Add(tokens[0]);
                        allTeams.Add(current);
                        Console.WriteLine($"Team {tokens[1]} has been created by {tokens[0]}!");
                    }

                    else if(teams.Contains(tokens[1]))
                    {
                        Console.WriteLine($"Team {tokens[1]} was already created!");
                    }

                    else if (!names.Contains(tokens[0]))
                    {
                        Console.WriteLine($"{tokens[0]} cannot create another team!");
                    }

                }

                command = Console.ReadLine();
            }

            List<List<Player>> listWithTeams = new List<List<Player>>(countTeams);
            List<Player> coppiedList = allTeams.GetRange(0, allTeams.Count);

            while (coppiedList.Count > 0)
            {
                Player currentPlayer = allTeams[0];
                List<Player> currentTeam = new List<Player>();
                currentTeam.Add(currentPlayer);
                coppiedList.RemoveAt(0);
                allTeams.RemoveAt(0);

                foreach (var item in allTeams)
                {
                    if(currentPlayer.TeamName == item.TeamName)
                    {
                        currentTeam.Add(item);
                        coppiedList.Remove(item);
                    }

                }

                listWithTeams.Add(currentTeam);
                allTeams = coppiedList.GetRange(0, coppiedList.Count);
            }

            //listWithTeams.Sort((a, b) => a.Count != b.Count ? b.Count - a.Count : a[0].TeamName.CompareTo(b[0].TeamName));


            List<List<Player>> teamsToDisband = new List<List<Player>>();
 
            for (int i = 0; i < listWithTeams.Count; i++)
            {
                List<Player> current = listWithTeams[i];

                if (current.Count > 1)
                {
                    Console.WriteLine(current[0].TeamName);
                    Console.WriteLine($"- {current[0].PlayerName}");

                    current.RemoveAt(0);
                    current.Sort((a, b) => a.PlayerName.CompareTo(b.PlayerName));

                    foreach (var item in current)
                    {
                        Console.WriteLine($"-- {item.PlayerName}");
                    }
                }
                else
                {
                    teamsToDisband.Add(current);
                }

            }

            Console.WriteLine("Teams to disband:");

            teamsToDisband.Sort((a, b) => a[0].TeamName.CompareTo(b[0].TeamName));

            foreach (var item in teamsToDisband)
            {
                Console.WriteLine(item[0].TeamName);
            }
        }
    }

    class Player
    {

        public Player(string playerName, string teamName)
        {
            PlayerName = playerName;
            TeamName = teamName;

        }

        public string PlayerName { get; set; }
        public string TeamName { get; set; }

        public override string ToString()
        {
            return $"{PlayerName} - {TeamName}";
        }

    }
}
