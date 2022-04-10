using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T, V, U>
    {
        private T key;
        private V quantity;
        private U item;

        public Tuple(T first, V second, U third)
        {
            key = first;
            quantity = second;
            item = third;
        }

        public T Key
        {
            get => this.key;
            private set => this.key = value;
        }

        public V Quantity
        {
            get => this.quantity;
            private set => this.quantity = value;
        }

        public U Item
        {
            get => this.item;
            private set => this.item = value;
        }
    }
}
