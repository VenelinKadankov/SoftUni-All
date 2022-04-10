using System;
using System.Collections.Generic;

namespace PermWithRep
{
    class PermWithRep
    {
        public static string[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Permute(0);
        }

        private static void Permute(int permIndex)
        {
            if (permIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }


            var swapped = new HashSet<string>() { elements[permIndex] };
            Permute(permIndex + 1);

            for (int i = permIndex + 1; i < elements.Length; i++)
            {
                if (!swapped.Contains(elements[i]))
                {
                    Swap(permIndex, i);
                    Permute(permIndex + 1);
                    Swap(permIndex, i);
                    swapped.Add(elements[i]);
                }

            }
        }

        private static void Swap(int permIndex, int i)
        {
            string swapped = elements[permIndex];
            elements[permIndex] = elements[i];
            elements[i] = swapped;
        }
    }
}
