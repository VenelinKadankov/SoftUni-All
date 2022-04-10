using System;
using System.Linq;

namespace CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();



            Array.Sort(arr, (a, b) =>
            {
                int result = 0;

                if (a % 2 == 0 && b % 2 != 0)
                {
                    result = -1;
                }
                else if (a % 2 != 0 && b % 2 == 0)
                {
                    result = 1;
                }
                else
                {
                    result = a - b;
                }

                return result;

            });

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
