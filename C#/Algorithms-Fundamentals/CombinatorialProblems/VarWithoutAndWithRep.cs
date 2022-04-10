using System;

namespace VariationsWithoutRep
{
    class VarWithoutAndWithRep
    {
        public static string[] elements;
        public static string[] variations;
        //public static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            variations = new string[int.Parse(Console.ReadLine())];
           // used = new bool[elements.Length];

            Vartiate(0);
        }

        private static void Vartiate(int varIndex)
        {
            if (varIndex >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
              //  if (!used[i])
              //  {
                //    used[i] = true;
                    variations[varIndex] = elements[i];
                    Vartiate(varIndex + 1);
                //    used[i] = false;
                //}
            }
        }
    }
}
