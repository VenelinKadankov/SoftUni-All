using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AppendArrays
{
    class AppendArrays
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                int[] arr = input[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                //Array.Sort(arr);

                result.AddRange(arr);
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
