using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myLinkedList = new DoublyLinkedList<string>();

            myLinkedList.AddFirst("Venjo");
            myLinkedList.AddFirst("Stoian");
            myLinkedList.AddFirst("Ivan");
            myLinkedList.RemoveFirst();

            myLinkedList.ForEach(a => Console.WriteLine(a));
        }
    }
}
