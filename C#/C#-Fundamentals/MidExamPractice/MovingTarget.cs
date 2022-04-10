using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class MovingTarget
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];
                int index = int.Parse(tokens[1]);
                int power = int.Parse(tokens[2]);

                if (action?.ToLower() == "shoot" && (index >= 0 && index < targets.Count))
                {
                    targets[index] -= power;

                    if(targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }

                }
                else if(action?.ToLower() == "add")
                {

                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, power);
                    } 
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }

                }
                else if(action?.ToLower() == "strike")
                {

                    if (index - power < 0 || index + 1 + power >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        targets.RemoveRange(index - power, power * 2 + 1);
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{string.Join("|", targets)}");
        }
    }
}
