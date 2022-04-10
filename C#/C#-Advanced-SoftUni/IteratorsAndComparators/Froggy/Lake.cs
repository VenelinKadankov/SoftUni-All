using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {

        private List<int> items;

        public IEnumerator<int> enumerator;


        public Lake(List<int> elements) 
        {
            this.items = elements;
            Count = items.Count;
        }

        public Lake()
        {
            this.items = new List<int>();
        }


        public int Count { get; set; }

        public List<int> Items { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i += 2)
            {
                yield return items[i];
            }

            for (int j = items.Count - 1; j >= 0; j--)
            {
                if (j % 2 != 0)
                {
                    yield return items[j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(int element)
        {
            items.Add(element);
            Count++;
        }

        public override string ToString()
        {
            return string.Join(", ", items.ToArray());
        }
    }
}
