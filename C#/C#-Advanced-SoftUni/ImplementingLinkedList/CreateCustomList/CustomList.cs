using System;

namespace MyCustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }

        }

        public void Add(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count++] = item;

        }

        private void Resize()
        {
            int[] temp = new int[items.Length * 2];
            Array.Copy(items, temp, items.Length);
            items = temp;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            this.items[index] = default;
            this.Count--;

            Shift(index);

            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }

            return this.items[index];
        }

        private void Shrink()
        {
            int[] temp = new int[this.items.Length / 2];
            Array.Copy(this.items, temp, this.items.Length);
            this.items = temp;
        }

        private void Shift(int index)
        {
            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[^1] = default;
        }

        public void Insert(int index, int item)
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                Resize();
            }

            ShiftRight(index);
            this.items[index] = item;
            this.Count++;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = default;
        }

        public bool Contains(int item)
        {
            bool result = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (items[i] == item)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= this.Count || secondIndex >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
    }
}
