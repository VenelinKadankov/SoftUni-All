using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class LogicForEnumeration : IEnumerator<int>
    {
        private int index = -1;
        private List<int> items;

        public LogicForEnumeration(List<int> elements)
        {
            this.items = elements;
        }

        public LogicForEnumeration()
        {

        }

        public List<int> Items { get; set; }
        public int Current => this.items[index];

        object IEnumerator.Current => this.Current;


        public void Dispose() { }

        public bool MoveNext()
        {
            index++;

            return index < this.items.Count;
            
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}
