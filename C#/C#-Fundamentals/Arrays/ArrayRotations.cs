using System;
using System.Linq;

namespace ArrayRotations
{
    class ArrayRotations
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());

            int shift = rotations % arr.Length;
            int[] newArr = new int[arr.Length];


            for (int i = 0; i < shift; i++)
            {
                int elementToRotate = arr[0];

                for (int j = 1; j < arr.Length; j++)
                {
                    int currentElement = arr[j];
                    arr[j - 1] = currentElement;
                }

                arr[arr.Length - 1] = elementToRotate;
            }

            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
