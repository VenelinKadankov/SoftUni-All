using System;
using System.Collections.Generic;
using System.Linq;

namespace MemmoryGame
{
    class MemmoryGame
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = Console.ReadLine();
            int counterMoves = 0;

            bool isWon = false;

            while (command?.ToLower() != "end")
            {
                int[] indexes = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                counterMoves++;
                string[] toInsert = { $"-{counterMoves}a", $"-{counterMoves}a" };

                if (Math.Min(indexes[0], indexes[1]) < 0 || Math.Max(indexes[0], indexes[1]) >= elements.Count)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    elements.InsertRange(elements.Count / 2, toInsert);
                }
                else
                {
                    if(elements[indexes[0]] == elements[indexes[1]])
                    {
                        string element = elements[indexes[0]];
                        elements.RemoveAt(Math.Max(indexes[0], indexes[1]));
                        elements.RemoveAt(Math.Min(indexes[0], indexes[1]));
                        Console.WriteLine($"Congrats! You have found matching elements - {element}!");
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }

                }

                if (elements.Count <= 0)
                {
                    Console.WriteLine($"You have won in {counterMoves} turns!");
                    isWon = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (!isWon)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine($"{string.Join(" ", elements)}");
            }
        }
    }
}
