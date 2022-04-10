using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<char> snake = new Queue<char>(Console.ReadLine());
            char[,] matrix = new char[dimentions[0], dimentions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char character = snake.Dequeue();
                        matrix[row, col] = character;
                        snake.Enqueue(character);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char character = snake.Dequeue();
                        matrix[row, col] = character;
                        snake.Enqueue(character);
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                StringBuilder sb = new StringBuilder();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
