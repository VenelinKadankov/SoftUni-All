using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterMode
{
    class PartyReservationFilterMode
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> filters = new List<string>();

            string command = Console.ReadLine();

            while (command?.ToUpper() != "PRINT")
            {
                string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string condition = $"{tokens[1]};{tokens[2]}";

                if (action == "Add filter")
                {
                    filters.Add(condition);
                }
                else
                {
                    filters.Remove(condition);
                }

                command = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                string[] tokens = filter.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string conditionType = tokens[0];
                string condition = tokens[1];

                switch (conditionType)
                {
                    case "Starts with":
                        names = names.Where(a => !a.StartsWith(condition)).ToList();
                        break;
                    case "Ends with":
                        names = names.Where(a => !a.EndsWith(condition)).ToList();
                        break;
                    case "Length":
                        names = names.Where(a => a.Length != int.Parse(condition)).ToList();
                        break;
                    case "Contains":
                        names = names.Where(a => !a.Contains(condition)).ToList();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
