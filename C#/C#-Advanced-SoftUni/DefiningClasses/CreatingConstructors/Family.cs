using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }
        public List<Person> Members { get; set; }

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public Person GetOldestMember()
        {
            int max = int.MinValue;
            string name = null;

            foreach (var person in this.Members)
            {
                if (person.Age > max)
                {
                    max = person.Age;
                    name = person.Name;
                }
            }

            return new Person(max, name);
        }
    }
}
