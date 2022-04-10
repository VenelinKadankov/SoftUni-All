using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var hats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var scarfs = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            var sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                var hat = hats.Pop();
                var scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    scarfs.Dequeue();
                }
                else if (hat == scarf)
                {
                    hat++;
                    hats.Push(hat);
                    scarfs.Dequeue();
                }
                //else
                //{

                //}
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
