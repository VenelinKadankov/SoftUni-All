using System;

namespace NestedLoopsToRecursion
{
    class NestedLoopsToRecursion
    {
        public static int[] variation;
        public static int limit;
        static void Main(string[] args)
        {
            limit = int.Parse(Console.ReadLine());
            variation = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                variation[i] = 1;
            }

            Iterate(0);
        }

        private static void Iterate(int index)
        {
            if (index >= limit)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int i = 0; i < limit; i++)
            {
                    variation[index] = i + 1;
                    Iterate(index + 1);
            }
        }
    }
}
