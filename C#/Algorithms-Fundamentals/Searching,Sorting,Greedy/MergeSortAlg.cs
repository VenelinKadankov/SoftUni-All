using System;
using System.Linq;

namespace MergeSortAlg
{
    class MergeSortAlg
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray();


            var sorted = MergeSort(arr);
            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            var left = arr.Take(arr.Length / 2).ToArray();
            var right = arr.Skip(arr.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var array = new int[left.Length + right.Length];
            int indexArr = 0;
            int indexLeft = 0;
            int indexRight = 0;

            while (indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] < right[indexRight])
                {
                    array[indexArr] = left[indexLeft];
                    indexLeft++;
                }
                else
                {
                    array[indexArr] = right[indexRight];
                    indexRight++;
                }

                indexArr++;
            }

            while (indexLeft < left.Length)
            {
                array[indexArr] = left[indexLeft];
                indexLeft++;
                indexArr++;
            }

            while (indexRight < right.Length)
            {
                array[indexArr] = right[indexRight];
                indexRight++;
                indexArr++;
            }

            return array;
        }
    }
}
