using System;
using System.Linq;

namespace BubbleSort
{
    class BubbleSort
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();


            BubleSort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void BubleSort(int[] arr)
        {
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;

                for (int i = 1; i < arr.Length; i++)
                {

                    if (arr[i] < arr[i - 1])
                    {
                        Swap(arr, i, i - 1);
                        isSorted = false;
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
