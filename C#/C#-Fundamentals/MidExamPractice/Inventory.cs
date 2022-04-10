using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Inventory
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] tokens = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0], item = tokens[1];

                if (action?.ToLower() == "collect" && !inventory.Contains(item))
                {
                    inventory.Add(item);
                }
                else if (action?.ToLower() == "drop" && inventory.Contains(item))
                {
                    inventory.Remove(item);
                }
                else if (action == "Combine Items")
                {
                    string[] items = item.Split(":").ToArray();
                    string old = items[0], newOne = items[1];

                    if (inventory.Contains(old))
                    {
                        inventory.Insert(inventory.IndexOf(old) + 1, newOne);
                    }
                }
                else if (action?.ToLower() == "renew" && inventory.Contains(item))
                {
                    inventory.Remove(item);
                    inventory.Add(item);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
