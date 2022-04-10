using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class OldestMember
    {
        static void Main(string[] args)
        {
            int countMembers = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < countMembers; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = line[0];
                int age = int.Parse(line[1]);
                Person member = new Person(name, age);

                family.AddMember(member);
            }

            Person wanted = family.GetOldestMember(family, countMembers);
            Console.WriteLine($"{wanted.Name} {wanted.Age}");
        }
    }

    class Family
    {
        public List<Person> listOfPeople { get; set; } = new List<Person>();

        public void AddMember(Person someone) 
        {
            listOfPeople.Add(someone);
        }

        public Person GetOldestMember(Family family, int count)
        {
            int oldestAge = int.MinValue;

           for (int i = 0; i < count; i++)
            {
                if (oldestAge < family.listOfPeople[i].Age)
                {
                    oldestAge = family.listOfPeople[i].Age;
                }
            }

            Person oldestPerson = family.listOfPeople.Find(a => a.Age == oldestAge);

            return oldestPerson;
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
