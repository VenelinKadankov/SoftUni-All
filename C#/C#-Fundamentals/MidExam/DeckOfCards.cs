using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    class DeckOfCards
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int countOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOperations; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];

                if (action?.ToLower() == "add")
                {
                    string type = tokens[1];

                    if (!cards.Contains(type))
                    {
                        cards.Add(type);
                        Console.WriteLine("Card successfully bought");
                    }
                    else
                    {
                        Console.WriteLine("Card is already bought");
                    }

                }
                else if (action?.ToLower() == "remove")
                {
                    string type = tokens[1];

                    if (cards.Contains(type))
                    {
                        cards.Remove(type);
                        Console.WriteLine("Card successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Card not found");
                    }

                }
                else if (action?.ToLower() == "remove at")
                {
                    int index = int.Parse(tokens[1]);

                    if (0 <= index && index < cards.Count)
                    {
                        cards.RemoveAt(index);
                        Console.WriteLine("Card successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Index out of range");
                    }

                }
                else if (action?.ToLower() == "insert")
                {
                    int index = int.Parse(tokens[1]);
                    string name = tokens[2];

                    if (index < 0 || index >= cards.Count)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else
                    {

                        if (!cards.Contains(name))
                        {
                            Console.WriteLine("Card successfully bought");
                            cards.Insert(index, name);
                        }
                        else
                        {
                            Console.WriteLine("Card is already bought");
                        }

                    }

                }

            }

            Console.WriteLine(string.Join(", ", cards));
        }
    }
}
