using System;
using System.Linq;

namespace RecursiveArray
{
    class RecursiveArray
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(CalcSum(arr, 0)); 
        }

        private static int CalcSum(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            return arr[index] + CalcSum(arr, index + 1);
        }
    }
}
