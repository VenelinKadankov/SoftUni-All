using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            int[,] matrix = new int[dimentions, dimentions];

            for (int row = 0; row < dimentions; row++)
            {
                int[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < dimentions; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<int[]> coordinates = new Queue<int[]>();

            for (int i = 0; i < tokens.Length; i++)
            {
                int[] current = tokens[i].Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                coordinates.Enqueue(current);
            }

            ;

            while (coordinates.Count > 0)
            {
                int[] bomb = coordinates.Dequeue();
                int row = bomb[0];
                int col = bomb[1];
                HitNeighbours(row, col, matrix);

            }

            int sum = 0;
            int counterAlive = 0;

            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    sum += item;
                    counterAlive++;
                }
            }

            Console.WriteLine($"Alive cells: {counterAlive}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < dimentions; row++)
            {
                for (int col = 0; col < dimentions; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }

        private static void HitNeighbours(int row, int col, int[,] matrix)
        {
            int power = matrix[row, col];

            if (power > 0)
            {
                matrix[row, col] -= power;

                if (row - 1 >= 0 && col - 1 >= 0 && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= power;
                }

                if (row - 1 >= 0 && col >= 0 && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= power;
                }

                if (row - 1 >= 0 && col + 1 < matrix.GetLength(1) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= power;
                }

                if (row >= 0 && col - 1 >= 0 && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= power;
                }

                if (row >= 0 && col + 1 < matrix.GetLength(1) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= power;
                }

                if (row + 1 < matrix.GetLength(0) && col - 1 >= 0 && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= power;
                }

                if (row + 1 < matrix.GetLength(0) && col >= 0 && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= power;
                }

                if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= power;
                }
            }

        }
    }
}
