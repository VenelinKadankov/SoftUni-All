using System;

namespace WorldTour
{
    class WorldTour
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string command = Console.ReadLine();

            while (command?.ToLower() != "travel")
            {
                string[] tokens = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                if (action.Contains("Add"))
                {
                    int index = int.Parse(tokens[1]);
                    string stop = tokens[2];

                    if (index >=0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, stop);
                    }
                    Console.WriteLine(stops);
                }
                else if (action.Contains("Remove"))
                {
                    int start = int.Parse(tokens[1]), end = int.Parse(tokens[2]);

                    if (start >= 0 && start < stops.Length && end >= 0 && end < stops.Length && end >= start)
                    {
                        stops = stops.Remove(start, end - start + 1);
                    }
                    Console.WriteLine(stops);
                }
                else if (action.Contains("Switch"))
                {
                    string old = tokens[1];
                    string newOne = tokens[2];
                    if (stops.Contains(old))
                    {
                        stops = stops.Replace(old, newOne);
                    }
                    Console.WriteLine(stops);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
