using System;

namespace MyCustomList
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Insert(5, 1);
            list.Swap(1, 4);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Contains(7));

            ;
        }
    }
}
