using System;
using System.Collections.Generic;
using System.Data;

namespace TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main(string[] args)
        {
            int countTeams = int.Parse(Console.ReadLine());
            List<Team> allTeams = new List<Team>(countTeams);
            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                if (command.Contains("->"))
                {
                    string[] tokens = command.Split("->");

                }
                else
                {
                    string[] tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                    Team current = new Team(tokens[0], tokens[1]);

                    bool isIncluded = false;

                    for (int i = 0; i < allTeams.Count; i++)
                    {
                        if (allTeams[i].TeamName == (current.TeamName))
                        {
                            isIncluded = true;
                        }
                    }

                    if (!isIncluded)
                    {
                        allTeams.Add(current);
                    } 
                    else
                    {
                        Console.WriteLine($"Team {tokens[0]} was already created!");
                    }

                }


                command = Console.ReadLine();
            }

            Console.WriteLine(allTeams.ToString());
        }
    }

    class Team
    {

        public Team(string teamName, string playerName)
        {
            TeamName = teamName;
            Players.Add(playerName);

        }

        public string TeamName { get; set; }
        public List<string> Players { get; set; }

        public override string ToString()
        {
            return $"{TeamName} - {string.Join(" ----- ", Players)}";
        }

    }
}
