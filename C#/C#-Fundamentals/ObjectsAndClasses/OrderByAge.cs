using System;
using System.Collections.Generic;

namespace OrderByAge
{
    class OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person current = new Person(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]));
                people.Add(current);

                command = Console.ReadLine();
            }

            people.Sort((a, b) => a.Age - b.Age);

            foreach (var item in people)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }

    class Person
    {
        public Person(string name, int number, int age)
        {
            Name = name;
            Number = number;
            Age = age;
        }

        public string Name { get; set; }
        public int Number { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Number} is {Age} years old.";
        }
    }
}
