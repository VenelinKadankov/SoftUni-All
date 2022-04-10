using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class MinerTask
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, int> valuables = new Dictionary<string, int>();

            while (command?.ToLower() != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (valuables.ContainsKey(command))
                {
                    valuables[command] += quantity;
                }
                else
                {
                    valuables.Add(command, quantity);
                }

                command = Console.ReadLine();
            }

            foreach (var item in valuables)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
