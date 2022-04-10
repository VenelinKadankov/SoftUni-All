using System;

namespace MyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myLinkedList = new LinkedList(new int[] { 2, 4, 6, 8, 9, 20});

            myLinkedList.AddFirst(4);
            var node = myLinkedList.Find(6);
            myLinkedList.AddFirst(44);
            myLinkedList.AddLast(166);
            myLinkedList.AddAfter(node, 1);
            node = myLinkedList.Find(9);
            myLinkedList.AddBefore(node, 3);

            myLinkedList.Remove(20);
            myLinkedList.Remove(node);
            myLinkedList.RemoveFirst();
            myLinkedList.RemoveLast();
            myLinkedList.RemoveAll(4);

            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(myLinkedList.Count);
            ;
        }
    }
}
