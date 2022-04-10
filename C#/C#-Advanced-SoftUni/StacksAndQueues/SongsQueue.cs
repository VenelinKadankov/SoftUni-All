using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));
            string command = Console.ReadLine();

            while (songs.Count > 0)
            {
                string[] line = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (line[0]?.ToLower() == "play")
                {
                    songs.Dequeue();
                }
                else if (line[0]?.ToLower() == "add")
                {
                    string song = string.Join(" ", line.Skip(1));

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }

                }
                else
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

             command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
