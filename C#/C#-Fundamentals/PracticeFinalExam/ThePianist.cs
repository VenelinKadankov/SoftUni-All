using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class ThePianist
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> songs = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];

                if (!songs.ContainsKey(piece))
                {
                    songs.Add(piece, new List<string>());
                }

                songs[piece].Add(composer);
                songs[piece].Add(key);
            }

            string command = Console.ReadLine();

            while (command?.ToLower() != "stop")
            {
                string[] tokens = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string piece = tokens[1];

                if (action?.ToLower() == "add")
                {
                    string composer = tokens[2];
                    string key = tokens[3];

                    if (songs.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        songs.Add(piece, new List<string>());
                        songs[piece].Add(composer);
                        songs[piece].Add(key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (action?.ToLower() == "remove")
                {
                    if (songs.ContainsKey(piece))
                    {
                        songs.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else
                {
                    string newKey = tokens[2];

                    if (songs.ContainsKey(piece))
                    {
                        songs[piece].RemoveAt(1);
                        songs[piece].Add(newKey);
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }

                command = Console.ReadLine();
            }

            var result = songs.OrderBy(a => a.Key).ThenBy(a => a.Value[0]).ToDictionary(b => b.Key, b => b.Value);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
 
        }
    }
}
