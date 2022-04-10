using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class MyCustomStack<T> : IEnumerable<T>
    {
        private T[] items;
        private int index = 0;

        public MyCustomStack()
        {
            items = new T[4];
            Count = 0;
        }

        public int Count { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            index = Count - index - 1;
            var element = items[index];

            while (element != null)
            {
                yield return element;

                if (index == 0)
                {
                    break;
                }

                element = items[--index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void GrowArray()
        {
            var temp = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                temp[i] = items[i];
            }

            items = temp;
        }
        public void Push(T[] itemsToAdd)
        {
            if (Count + itemsToAdd.Length > items.Length)
            {
                GrowArray();
            }

            var newLength = Count + itemsToAdd.Length;
            int counter = 0;

            for (int i = Count; i < newLength; i++)
            {
                items[i] = itemsToAdd[counter];
                counter++;
            }

            Count = newLength;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                Console.WriteLine("No elements");
                //throw new InvalidOperationException("No elements");
            }

            Count--;
            var temp = items[^1];
            items[^1] = default;
            return temp;
        }

    }
}
