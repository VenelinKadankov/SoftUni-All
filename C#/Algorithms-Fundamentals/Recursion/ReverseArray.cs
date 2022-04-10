using System;

namespace ReverseArray
{
    class ReverseArray
    {
        public static string[] arr;
        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Reverse(0);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Reverse(int indexSwapped)
        {
            if (indexSwapped >= arr.Length / 2)
            {
                return;
            }

            Swap(indexSwapped, arr.Length - 1 - indexSwapped);
            Reverse(indexSwapped + 1);
        }

        private static void Swap(int v1, int v2)
        {
            string swapped = arr[v1];
            arr[v1] = arr[v2];
            arr[v2] = swapped;
        }
    }
}
