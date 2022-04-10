using System;
using System.Collections.Generic;

namespace GenericBox
{
    public class BoxCollection<T> where T : IComparable
    {
        private List<Box<T>> list;

        public BoxCollection()
        {
            this.list = new List<Box<T>>();
        }


        public void AddBox(Box<T> box)
        {
            list.Add(box);
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    foreach (var line in list)
        //    {
        //        sb.AppendLine($"{line}");
        //    }

        //    return sb.ToString();

        //}

        //public void Swap(int firstIndex, int secondIndex)
        //{
        //    var temp = this.list[firstIndex];
        //    this.list[firstIndex] = this.list[secondIndex];
        //    this.list[secondIndex] = temp;
        //}

        public int CompareValue<V>(T comparator)
        {
            int count = 0;

            foreach (var box in list)
            {
                if (box.CompareTo(comparator) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
