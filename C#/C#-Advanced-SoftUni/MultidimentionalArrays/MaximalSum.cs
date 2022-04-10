using System;
using System.Linq;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];
            int maxSum = int.MinValue;
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }


            Console.WriteLine($"Sum = {maxSum}");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{matrix[startRow + i, startCol]} {matrix[startRow + i, startCol + 1]} {matrix[startRow + i, startCol + 2]}");
            }
          //  Console.WriteLine($"{matrix[startRow + 1, startCol]} {matrix[startRow + 1,startCol + 1]} {matrix[startRow + 1, startCol + 2]}");
           // Console.WriteLine($"{matrix[startRow + 2, startCol]} {matrix[startRow + 2,startCol + 1]} {matrix[startRow + 2, startCol + 2]}");
        }
    }
}
