using System;

namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            BoxCollection<string> list = new BoxCollection<string>();

            for (int i = 0; i < count; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                list.AddBox(box);
            }

            string comparator = Console.ReadLine();
            //int[] indexes = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //list.Swap(indexes[0], indexes[1]);
            //Console.WriteLine(list.ToString());

            int total = list.CompareValue<string>(comparator);
            Console.WriteLine(total);
        }

    }
}
