using System;
using System.Diagnostics.CodeAnalysis;

namespace GenericBox
{
    public class Box<T> where T : IComparable
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get => this.value;
            private set => this.value = value;
        }

        public int CompareTo([AllowNull] T other)
        {
            return this.value.CompareTo(other);
        }


        //public override string ToString()
        //{
        //    return $"{this.value.GetType()}: {this.value}";
        //}
    }
}
