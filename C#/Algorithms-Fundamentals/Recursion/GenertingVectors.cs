using System;

namespace GeneratingVectors
{
    class GenertingVectors
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var vector = new int[n];

            CreateVec(vector, 0);
        }

        private static void CreateVec(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                CreateVec(vector, index + 1);
            }

        }
    }
}
