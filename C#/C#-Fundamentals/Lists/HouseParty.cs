using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class HouseParty
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>(lines);

            for (int i = 0; i < lines; i++)
            {
                string[] currentLine = Console.ReadLine()
                    .Split(" is ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = currentLine[0];
                string status = currentLine[1];

                if(status.ToUpper() == "GOING!")
                {
                    if (!guests.Contains(name))
                    {
                        guests.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }

                }
                else
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            guests.ForEach(name => Console.WriteLine(name));
        }
    }
}
