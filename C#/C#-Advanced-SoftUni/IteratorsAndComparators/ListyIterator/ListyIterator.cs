using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>   // : IEnumerator<T>
    {
        private int index;
        public ListyIterator(List<T> list)
        {
            List = list;
            index = 0;
        }

        public List<T> List { get; set; }

        public T Current => List[index];

      //  object IEnumerator.Current => List[index];

        public void Dispose() { }

        public bool HasNext()
        {
            int next = index + 1;
            return  next < List.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public bool Move()
        {
            if (index + 1 < List.Count)
            {
                index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (List.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(List[index]);
            }
        }

        public bool MoveNext()
        {
            return ++index < List.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var element = List[index];

            while (element != null)
            {
                yield return element;
                MoveNext();
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PrintAll()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in List)
            {
                sb.Append(item + " ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
