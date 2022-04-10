using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class TupleCollection<T>
    {
        private List<T> list;

        public TupleCollection()
        {
            this.list = new List<T>();
        }

        public List<T> List
        {
            get => this.List;
            private set => this.List = value;
        }

        public void AddTuple(T elementToAdd)
        {
            this.list.Add(elementToAdd);
        }
    }
}
