using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(arr, target));
        }

        private static int BinarySearch(int[] arr, int target)
        {
            int start = 0;
            int end = arr.Length - 1;
            int middle = (start + end) / 2;

            while (start <= end)
            {
                if (arr[middle] == target)
                {
                    return middle;
                }
                if (arr[middle] < target)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }

                middle = (start + end) / 2;
            }

            return -1;
        }
    }
}
