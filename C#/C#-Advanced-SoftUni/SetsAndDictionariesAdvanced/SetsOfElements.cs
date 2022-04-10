using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> first = new HashSet<int>(lengths[0]);
            HashSet<int> second = new HashSet<int>(lengths[1]);

            for (int i = 0; i < lengths[0] + lengths[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i < lengths[0])
                {
                    first.Add(num);
                }
                else
                {
                    second.Add(num);
                }
            }

            //HashSet<int> result = new HashSet<int>();
            first.IntersectWith(second);
            //foreach (var item in first)
            //{
            //    if (second.Contains(item))
            //    {
            //        result.Add(item);
            //    }
            //}

            Console.WriteLine(string.Join(" ", first));
        }
    }
}
