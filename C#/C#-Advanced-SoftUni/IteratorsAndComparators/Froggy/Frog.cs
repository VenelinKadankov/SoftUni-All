using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Frog
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            ;
            Lake originalLake = new Lake(list);
            Lake result = new Lake();

            foreach (var item in originalLake)
            {
                result.Add(item);
            }

            Console.WriteLine(result.ToString());
            ;
        }
    }
}
