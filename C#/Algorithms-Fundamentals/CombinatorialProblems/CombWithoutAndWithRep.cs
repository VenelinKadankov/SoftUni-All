using System;

namespace CombinationsWithoutRep
{
    class CombWithoutAndWithRep
    {
        public static string[] elements;
        public static string[] combinations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            combinations = new string[int.Parse(Console.ReadLine())];

            Combinations(0, 0);
        }

        private static void Combinations(int combIndex, int elementIndex)
        {
            if (combIndex >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementIndex; i < elements.Length; i++)
            {
                    combinations[combIndex] = elements[i];
                    Combinations(combIndex + 1, i + 1); //tuka e (combIndex + 1, i) za drugoto - s povtorenie
            }
        }
    }
}
