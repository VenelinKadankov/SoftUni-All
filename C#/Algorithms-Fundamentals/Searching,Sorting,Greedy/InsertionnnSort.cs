using System;
using System.Linq;

namespace InsertionSort
{
    class InsertionnnSort
    {

        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();


            InsertionSort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }


        private static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0 && arr[j - 1] > arr[j])
                {
                    Swap(arr, j, j - 1);
                    j -= 1;
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
