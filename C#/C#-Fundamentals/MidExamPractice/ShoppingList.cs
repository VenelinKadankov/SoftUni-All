using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class ShoppingList
    {
        static void Main(string[] args)
        {
            List<string> groceryList = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Go Shopping!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0], product = tokens[1];

                switch (action)
                {
                    case "Urgent":
                        groceryList = Urgent(groceryList, product);
                        break;
                    case "Unnecessary":
                        groceryList = Unnecessary(groceryList, product);
                        break;
                    case "Correct":
                        string newName = tokens[2];
                        groceryList = Correct(groceryList, product, newName);
                        break;
                    case "Rearrange":
                        groceryList = Rearrange(groceryList, product);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceryList));
        }

        static List<string> Urgent(List<string> list, string item)
        {
            if (!list.Contains(item))
            {
                list.Insert(0, item);
            }

            return list;
        }

        static List<string> Unnecessary(List<string> list, string item)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
            }

            return list;
        }

        static List<string> Correct(List<string> list, string item, string newName)
        {
            if (list.Contains(item))
            {
                int index = list.IndexOf(item);
                list.Remove(item);
                list.Insert(index, newName);
            }

            return list;
        }

        static List<string> Rearrange(List<string> list, string item)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
                list.Add(item);
            }

            return list;
        }
    }
}
