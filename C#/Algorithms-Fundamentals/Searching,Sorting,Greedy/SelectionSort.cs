using System;
using System.Linq;

namespace SelectionSort
{
    class SelectionSort
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SelectSort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                int minNumber = arr[minIndex];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < minNumber)
                    {
                        minNumber = arr[j];
                        minIndex = j;
                        Swap(arr, i, j);
                    }
                }
            }
        }

        private static void Swap(int[] arr, int first, int second)
        {
            var toSwap = arr[first];
            arr[first] = arr[second];
            arr[second] = toSwap;
        }
    }
}
