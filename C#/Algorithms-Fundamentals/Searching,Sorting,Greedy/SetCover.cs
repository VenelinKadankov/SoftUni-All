using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class SetCover
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int countSets = int.Parse(Console.ReadLine());
            var sortedByLength = new List<List<int>>();
            int counter = 0;
            var result = new List<List<int>>();

            for (int i = 0; i < countSets; i++)
            {
                List<int> miniSet = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                sortedByLength.Add(miniSet);
            }

            //sortedByLength = sortedByLength.OrderByDescending(a => a.Count(b => sequence.Contains(b))).FirstOrDefault().ToList();

            while (sequence.Count > 0)
            {
                //var longest = HasMostEqual(sequence, sortedByLength);
                var longest = sortedByLength.OrderByDescending(a => a.Count(b => sequence.Contains(b))).FirstOrDefault().ToList();
                RemoveElements(sequence, longest);
                sortedByLength.Remove(longest);
                result.Add(longest);
                counter++;

            }

            Console.WriteLine($"Sets to take ({counter}):");
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }

        private static void RemoveElements(List<int> sequence, List<int> longest)
        {
            foreach (var item in longest)
            {
                if (sequence.Contains(item))
                {
                    sequence.Remove(item);
                }
            }
        }

    }
}
