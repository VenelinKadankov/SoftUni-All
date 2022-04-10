using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int capacity = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (commands[0].ToUpper() != "END")
            {
                if (commands[0].ToUpper() == "ADD")
                {
                    wagons.Add(int.Parse(commands[1]));
                } 
                else
                {
                    int passengers = int.Parse(commands[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= capacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }

                commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
