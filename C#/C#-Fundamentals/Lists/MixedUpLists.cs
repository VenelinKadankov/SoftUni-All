using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            List<int> secondList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>(firstList.Count + secondList.Count - 2);

            while(Math.Min(firstList.Count, secondList.Count) > 0)
            {
                result.Add(firstList[0]);
                result.Add(secondList[secondList.Count - 1]);

                firstList.RemoveAt(0);
                secondList.RemoveAt(secondList.Count - 1);
            }

            int lowerBorder = 0;
            int upperBorder = 0;

            if(firstList.Count > 0)
            {
                lowerBorder = Math.Min(firstList[0], firstList[1]);
                upperBorder = Math.Max(firstList[0], firstList[1]);
            }
            else
            {
                lowerBorder = Math.Min(secondList[0], secondList[1]);
                upperBorder = Math.Max(secondList[0], secondList[1]);
            }

            List<int> output = result.Where(a => a > lowerBorder && a < upperBorder).ToList();
            output.Sort((a, b) => a - b);
            Console.WriteLine(string.Join(' ', output));
        }
    }
}
