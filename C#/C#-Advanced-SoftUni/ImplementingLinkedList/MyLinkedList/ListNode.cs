using System;
using System.Collections.Generic;
using System.Text;

namespace MyLinkedList
{
    public class ListNode
    {
        public ListNode(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Node in my list
        /// </summary>
        public ListNode Next { get; set; }


        /// <summary>
        /// Value of node
        /// </summary>
        public int Value { get; set; }
    }
}
