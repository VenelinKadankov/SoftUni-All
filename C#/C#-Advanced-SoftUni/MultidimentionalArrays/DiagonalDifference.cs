using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int i = 0; i < size; i++)
            {
                firstDiagonal += matrix[i, i];
                secondDiagonal += matrix[i, size - 1 - i];
            }

            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }
    }
}
