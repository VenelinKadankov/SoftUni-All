using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private class ListNode
        {
            /// <summary>
            /// Node of the linked list
            /// </summary>
            /// <param name="comingFrom">comming from node</param>
            /// <param name="value">value of node</param>
            /// <param name="goingTo">going to node</param>
            public ListNode(T value)
            {
                this.Value = value;
            }
            public ListNode Previous { get; set; }

            public T Value { get; set; }

            public ListNode Next { get; set; }
        }

        /// <summary>
        /// First node in collection
        /// </summary>
        private ListNode First;

        /// <summary>
        /// Last node in collection
        /// </summary>
        private ListNode Last;

        /// <summary>
        /// Count of nodes in collection
        /// </summary>
        public int Count { get; private set; }


        /// <summary>
        /// Add node at the beginning of collection
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="element">value to add</param>
        public void AddFirst(T element)
        {
            var newElement = new ListNode(element);

            if (this.Count == 0)
            {
                this.First = this.Last = newElement;
            }
            else
            {
                newElement.Next = this.First;
                this.First.Previous = newElement;
                this.First = newElement;

            }

            Count++;
        }

        /// <summary>
        /// Add node at at end of collection
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="element">value to add</param>
        public void AddLast(T element)
        {
            var newLast = new ListNode(element);

            if (Count == 0)
            {
                First = Last = newLast;
            }
            else
            {
                newLast.Previous = this.Last;
                this.Last.Next = newLast;
                this.Last = newLast;
            }

            Count++;
        }

        /// <summary>
        /// Remove first node in collection
        /// </summary>
        /// <returns>returns removed node</returns>
        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Can not remove node from empty collection");
            }

            var node = this.First.Value;
            this.First = this.First.Next;
            if (this.First != null)
            {
                this.First.Previous = null;
            }
            else
            {
                this.Last = null;
            }

            this.Count--;
            return node;
        }

        /// <summary>
        /// Remove last node in collection
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <returns>returns removed node</returns>
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Can no remove node from empty collection");
            }

            var element = this.Last.Value;
            this.Last = this.Last.Previous;

            if (this.Last != null)
            {
                this.Last.Next = null;
            }
            else
            {
                this.First = null;
            }

            this.Count--;
            return element;
        }

        /// <summary>
        /// For each method
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<T> action)
        {
            var currentNode = this.First;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Create an array from MyLinkedList
        /// </summary>
        /// <returns>an array of values</returns>
        public T[] ToArray()
        {
            T[] arr = new T[this.Count];
            int counter = 0;
            var current = this.First;

            while(current != null)
            {
                arr[counter] = current.Value;
                counter++;

                current = current.Next;
            }

            return arr;
        }
    }
}
