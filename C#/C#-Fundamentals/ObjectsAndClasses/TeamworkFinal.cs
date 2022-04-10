using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkFinal
{
    class TeamworkFinal
    {
        static void Main(string[] args)
        {
            int countTeams = int.Parse(Console.ReadLine());
            List<Team> teams = CreateTeam(countTeams);
            List<Team> teamsWithMembers = AddMembers(teams);
            OrderAndPrintResult(teamsWithMembers);
        }


        private static List<Team> CreateTeam(int num)
        {
            List<Team> allTeams = new List<Team>(num);

            for (int i = 0; i < num; i++)
            {
                string[] line = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Team current = new Team(line[0], line[1]);

                if (!allTeams.Select(a => a.TeamName).Contains(line[1]))
                {
                    if (!allTeams.Select(b => b.Creator).Contains(line[0]))
                    {
                        allTeams.Add(current);
                        Console.WriteLine($"Team {line[1]} has been created by {line[0]}!");
                    }
                    else
                    {
                        Console.WriteLine($"{line[0]} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {line[1]} was already created!");
                }

            }

            allTeams.ToList();
            return allTeams;
        }


        private static List<Team> AddMembers(List<Team> allTeams)
        {
            string command = Console.ReadLine();


            while (command != "end of assignment")
            {
                string[] memb = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = memb[0], team = memb[1];

                if (!allTeams.Select(a => a.TeamName).Contains(team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else
                {
                    if (allTeams.Select(a => a.Members).Any(x => x.Contains(name)))
                    {
                        Console.WriteLine($"Member {name} cannot join team {team}!");
                    }
                    else
                    {
                        int teamIndex = allTeams.FindIndex(b => b.TeamName == team);
                        allTeams[teamIndex].Members.Add(name);
                    }

                }

                command = Console.ReadLine();
            }

            allTeams.ToList();
            return allTeams;
        }


        public static void OrderAndPrintResult(List<Team> teams)
        {
            List<Team> finalList = teams.Where(a => a.Members.Count > 1).ToList();
            List<Team> disband = teams.OrderBy(x => x.TeamName).Where(a => a.Members.Count == 1).ToList();
            finalList.Sort((a, b) => a.Members.Count != b.Members.Count ? b.Members.Count - a.Members.Count : a.TeamName.CompareTo(b.TeamName));

            for (int i = 0; i < finalList.Count; i++)
            {
                Team current = finalList[i];
                string creator = current.Members[0];
                var members = current.Members.GetRange(1, current.Members.Count - 1);
                members.Sort();


                Console.WriteLine($"{current.TeamName}");
                Console.WriteLine($"- {current.Creator}");

                foreach (var item in members)
                {
                    Console.WriteLine($"-- {item}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var item in disband)
            {
                Console.WriteLine($"{item.TeamName}");
            }
            
        }

    }

    class Team
    {
        public Team(string creator, string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            Members.Add(creator);
        }

        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; } = new List<string>();

    }

}
