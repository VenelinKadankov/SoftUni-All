using System;
using System.Linq;

namespace QuickSort
{
    class QuickSortAlgo
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] && arr[right] < arr[pivot])
                {
                    Swap(arr, left, right);
                }

                if (arr[left] <= arr[pivot])
                {
                    left++;
                }

                if (arr[right] >= arr[pivot])
                {
                    right--;
                }
            }

                Swap(arr, pivot, right);
                bool isLeftSmaller = right - 1 - start < end - (right + 1);

                if (isLeftSmaller)
                {
                    QuickSort(arr, start, right - 1);
                    QuickSort(arr, right + 1, end);
                }
                else
                {
                    QuickSort(arr, right + 1, end);
                    QuickSort(arr, start, right - 1);
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
