using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            int[] delimiters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> checker = (a, arr) =>
            {
                bool isDivisible = true;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (a % arr[i] != 0)
                    {
                        isDivisible = false;
                        break;
                    }
                }

                return isDivisible;
            };

            List<int> result = new List<int>();

            for (int i = 0; i < limit; i++)
            {
                int num = i + 1;

                if (checker(num, delimiters))
                {
                    result.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
