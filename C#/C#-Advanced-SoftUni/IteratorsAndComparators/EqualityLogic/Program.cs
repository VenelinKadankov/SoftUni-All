using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<Person> hashset = new HashSet<Person>();
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);
                hashset.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashset.Count);
        }
    }
}
