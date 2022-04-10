using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family();
            //family.Members = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person member = new Person(age, name);

                family.AddMember(member);
            }

            if (family.Members.Count > 0)
            {
                Console.WriteLine(family.GetOldestMember().Name + " " + family.GetOldestMember().Age);
            }

        }
    }
}
