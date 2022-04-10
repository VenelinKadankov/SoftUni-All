using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Judge
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contenders = new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();
            Dictionary<string, int> allTogether = new Dictionary<string, int>();

            while (command != "no more time")
            {
                string[] tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string userName = tokens[0], contest = tokens[1];
                int points = int.Parse(tokens[2]);

                if (allTogether.ContainsKey(userName))
                {

                    // if (allTogether[person] < point)
                    // {
                    allTogether[userName] += points;
                    // }
                }
                else
                {
                    allTogether.Add(userName, points);
                }


                if (contenders.ContainsKey(contest))
                {
                    if (contenders[contest].ContainsKey(userName))
                    {
                        if (contenders[contest][userName] < points)
                        {
                            contenders[contest][userName] = points;
                        }
                    }
                    else
                    {
                        contenders[contest].Add(userName, points);
                    }

                }
                else
                {
                    contenders.Add(contest, new Dictionary<string, int>());
                    contenders[contest].Add(userName, points);
                }

                command = Console.ReadLine();
            }

            // Dictionary<string, int> allTogether = new Dictionary<string, int>();

            //  foreach (var item in contenders)
            // {
            //    Dictionary<string, int> names = item.Value;

            //    foreach (var name in names)
            //    {
            //        string person = name.Key;
            //         int point = name.Value;

            //        if (allTogether.ContainsKey(person))
            //        {

            // if (allTogether[person] < point)
            // {
            //               allTogether[person] += point;
            // }
            //      }
            //      else
            //    {
            //        allTogether.Add(person, point);
            //     }

            //  }

            // }



            foreach (var item in contenders)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");

                var res = item.Value.OrderByDescending(a => a.Value)
                    .ThenBy(b => b.Key)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
                int counter = 1;

                foreach (var line in res)
                {
                    Console.WriteLine($"{counter}. {line.Key} <::> {line.Value}");
                    counter++;
                }
            }

            Console.WriteLine("Individual standings: ");
            int counter2 = 1;
            var result2 = allTogether.OrderByDescending(a => a.Value).ThenBy(a => a.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in result2)
            {
                Console.WriteLine($"{counter2}. {item.Key} -> {item.Value}");
                counter2++;
            }
        }
    }
}
