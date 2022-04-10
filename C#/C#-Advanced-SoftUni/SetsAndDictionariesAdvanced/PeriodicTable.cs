using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] els = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in els)
                {
                    elements.Add(item);
                }
            }
            var result = elements.ToList().OrderBy(a => a).ToList();
            Console.WriteLine(string.Join(" ", result));
        }   
    }
}
