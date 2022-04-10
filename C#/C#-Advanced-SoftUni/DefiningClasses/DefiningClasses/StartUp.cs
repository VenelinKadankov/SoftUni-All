using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = line[0];
                int age = int.Parse(line[1]);

                Person current = new Person(age, name);

                if (age > 30)
                {
                    people.Add(current);
                }
            }

            people = people.OrderBy(a => a.Name).ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
