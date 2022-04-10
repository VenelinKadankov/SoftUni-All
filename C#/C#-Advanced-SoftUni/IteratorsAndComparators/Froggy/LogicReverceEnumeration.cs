using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class LogicReverceEnumeration : IEnumerator<int>
    {
        private List<int> items;

        private int index;


        public LogicReverceEnumeration(List<int> elements)
        {
            this.items = elements;
            index = items.Count;
        }

        public LogicReverceEnumeration()
        {

        }

        //public List<int> Items { get; set; }
        public int Current => this.items[index];
        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            index--;

            return index >= 0;
        }

        public void Reset()
        {
            this.index = this.items.Count;
        }
    }
}
