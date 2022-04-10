using System;

namespace PermutationsWithoutRepetition
{
    class PermutationsWithputRep
    {
        public static string[] elements;
        public static string[] permutations;
        public static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);
        }

        private static void Permute(int indexPerm)
        {
            if (indexPerm >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[indexPerm] = elements[i];
                    Permute(indexPerm + 1);
                    used[i] = false;
                }
            }
        }
    }
}
