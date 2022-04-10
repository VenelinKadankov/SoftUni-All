using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects
{
    public class ListOfPerson<Person> : IEnumerable<int>
    {
        private List<Person> items;

        public ListOfPerson()
        {
            items = new List<Person>();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(Person person)
        {
            this.items.Add(person);
        }
    }
}
