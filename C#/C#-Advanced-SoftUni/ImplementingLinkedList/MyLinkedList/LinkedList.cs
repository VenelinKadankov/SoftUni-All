using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyLinkedList
{
    public class LinkedList : IEnumerable<int>
    {
        /// <summary>
        /// First node in collection
        /// </summary>
        public ListNode First { get; set; }

        /// <summary>
        /// Last node in collection
        /// </summary>
        public ListNode Last { get; set; }

        /// <summary>
        /// Count nodes in collection
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Create empty linked list
        /// </summary>
        public LinkedList()
        {
            this.Count = 0;
        }

        /// <summary>
        /// Create linked list from collection
        /// </summary>
        /// <param name="collection">collection to add</param>
        public LinkedList(IEnumerable<int> collection) : this()
        {
            foreach (var value in collection)
            {
                this.AddLast(value);
            }

        }

        /// <summary>
        /// Add node at the end of collection
        /// </summary>
        /// <param name="value">value to add</param>
        public void AddLast(int value)
        {
            var newElement = new ListNode(value);

            if (Last == null)
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                Last.Next = newElement;
                Last = newElement;
            }

            Count++;
        }


        /// <summary>
        /// Add node at the beginning of collection
        /// </summary>
        /// <param name="value">value to add</param>
        public void AddFirst(int value)
        {
            var newElement = new ListNode(value);

            if (First == null)
            {
                First = newElement;
                Last = newElement;
            }

            newElement.Next = First;
            First = newElement;

            Count++;
        }

        /// <summary>
        /// Gets Enumerator for linked list
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
        {
            ListNode current = First;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        /// <summary>
        /// Gets Enumerator for linked list
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Checks if value is in the list
        /// </summary>
        /// <param name="value">value to check for</param>
        /// <returns></returns>
        public bool Contains(int value)
        {
            bool result = false;
            var newElement = new ListNode(value);

            while (newElement != null)
            {
                if (newElement.Value == value)
                {
                    result = true;
                    break;
                }

                newElement = newElement.Next;
            }

            return result;
        }

        /// <summary>
        /// Finds if node is included int the collection
        /// </summary>
        /// <param name="value">value of node to find</param>
        /// <returns></returns>
        public ListNode Find(int value)
        {
            ListNode result = null;
            var current = First;

            if (current == null)
            {
                throw new ArgumentNullException("Node can not be null");
            }

            while (current != null)
            {
                if (current.Value == value)
                {
                    result = current;
                    break;
                }

                current = current.Next;
            }

            return result;
        }

        /// <summary>
        /// Add new node after given
        /// </summary>
        /// <param name="node">node after which to add</param>
        /// <param name="value">value to add</param>
        public void AddAfter(ListNode node, int value)
        {
            var newElement = new ListNode(value);

            if (newElement == null)
            {
                throw new ArgumentNullException("Node can not be null");
            }

            newElement.Next = node.Next;
            node.Next = newElement;
            Count++;
        }

        /// <summary>
        /// Adds node before givven
        /// </summary>
        /// <param name="node">node to before which to add</param>
        /// <param name="value">value to add</param>
        public void AddBefore(ListNode node, int value)
        {

            if (node == null)
            {
                throw new ArgumentNullException("Node can not be null");
            }

            var newElement = new ListNode(value);

            if (node == First)
            {
                newElement.Next = First;
                First = newElement;
            }
            else
            {
                var current = First;

                while (current != null)
                {
                    if (current.Next == node)
                    {
                        newElement.Next = node;
                        current.Next = newElement;
                        break;
                    }

                    current = current.Next;
                }
            }
            Count++;
        }

        /// <summary>
        /// Removes node by value
        /// </summary>
        /// <param name="value">value to remove</param>
        public void Remove(int value)
        {

            if (First.Value == value)
            {
                First = First.Next;
            }

            var current = First;

            while (current != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    break;
                }

                current = current.Next;
            }

            Count--;
        }


        /// <summary>
        /// Remove node from list
        /// </summary>
        /// <param name="node">node to remove</param>
        public void Remove(ListNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node cannot be null");
            }

            if (First == node)
            {
                First = First.Next;
            }
            else
            {
                var current = First;

                while (current != null)
                {
                    if (current.Next == node)
                    {
                        current.Next = node.Next;
                        break;
                    }

                    current = current.Next;
                }
            }

            Count--;
        }

        /// <summary>
        /// Remove all occurances of a given value
        /// </summary>
        /// <param name="value">value to remove</param>
        public void RemoveAll(int value)
        {
            var current = Find(value);

            while (current != null)
            {
                Remove(current);

                current = Find(value);
            }

        }

        /// <summary>
        /// Removes first node in list
        /// </summary>
        public void RemoveFirst()
        {
            if (First != null)
            {
                if (First == Last)
                {
                    Last = null;
                }

                First = First.Next;
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (First == Last)
            {
                Last = First = null;
            }

            var current = First;

            while (current != null)
            {
                if (current.Next == Last)
                {
                    current.Next = null;
                    Last = current;
                }

                current = current.Next;
            }
            Count--;
        }

    }
}
