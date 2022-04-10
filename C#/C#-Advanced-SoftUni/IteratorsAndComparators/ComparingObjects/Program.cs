using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = Console.ReadLine();

            while (command?.ToUpper() != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                Person current = new Person(name, age, town);
                people.Add(current);

                command = Console.ReadLine();
            }

            bool isMatched = true;
            int indexWanter = int.Parse(Console.ReadLine());
            if (indexWanter >= people.Count)
            {
                isMatched = false;
                Console.WriteLine("No matches");

            }
            else
            {
                Person compared = people[indexWanter];
                int matches = 0;

                foreach (var item in people)
                {
                    if (item.CompareTo(compared) == 0)
                    {
                        matches++;
                    }
                }

                if (isMatched)
                {
                    Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
        }
    }
}
