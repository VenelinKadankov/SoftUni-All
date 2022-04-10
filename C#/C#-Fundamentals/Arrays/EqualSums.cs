using System;
using System.Linq;

namespace EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int leftSum = 0;
            int rightSum = 0;
            int index = 0;
            bool isEqual = false;

            for (int i = 0; i <arr.Length; i++)
            {
                int comparedNumber = arr[i];
                index = i;
                leftSum = 0;
                rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }

                for (int k = arr.Length - 1; k > i  ; k--)
                {
                    rightSum += arr[k];
                }

                if (leftSum == rightSum)
                {
                    isEqual = true;
                    break;
                }
            }

            if (isEqual)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
