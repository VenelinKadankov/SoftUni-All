using System;

namespace CombinationWithAnWithoutRep
{
    class Combinations
    {
        public static int[] variations;
        public static int[] elements;
       // public static bool[] used;
        static void Main(string[] args)
        {
            int countElements = int.Parse(Console.ReadLine());
            int lengthVar = int.Parse(Console.ReadLine());
            elements = new int[countElements];
           // used = new bool[countElements];
            variations = new int[lengthVar];

            for (int i = 0; i < countElements; i++)
            {
                elements[i] = i + 1;
            }

            Combinate(0, 0);
        }

        private static void Combinate(int indexComb, int indexElement)
        {
            if (indexComb >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = indexElement; i < elements.Length; i++)
            {
              //  if (!used[i])
               // {
               //     used[i] = true;
                    variations[indexComb] = elements[i];
                    Combinate(indexComb + 1, i);
               //     used[i] = false;
                //}

            }
         
        }
    }
}
