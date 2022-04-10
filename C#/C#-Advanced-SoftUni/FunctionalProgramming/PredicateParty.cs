using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {

                List<string> result = new List<string>();
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string condition = tokens[1];
                string startEndLength = tokens[2];

                if (int.TryParse(startEndLength, out int length))
                {
                    length = int.Parse(startEndLength);
                }

                if (action == "Remove")
                {
                    switch (condition)
                    {
                        case "StartsWith":
                            names = names.Where(a => !a.StartsWith(startEndLength)).ToList();
                            break;
                        case "EndsWith":
                            names = names.Where(a => !a.EndsWith(startEndLength)).ToList();
                            break;
                        case "Length":
                            names = names.Where(a => a.Length != length).ToList();
                            break;
                        default:
                            break;
                    }
                }
                else if (action == "Double")
                {


                    foreach (var name in names)
                    {
                        result.Add(name);

                        if (condition == "StartsWith" && name.StartsWith(startEndLength))
                        {
                            result.Add(name);
                        }
                        else if (condition == "EndsWith" && name.EndsWith(startEndLength))
                        {
                            result.Add(name);
                        }
                        else if (condition == "Length" && name.Length == length)
                        {
                            result.Add(name);
                        }

                    }

                    names = result;
                }

                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }


    }
}
