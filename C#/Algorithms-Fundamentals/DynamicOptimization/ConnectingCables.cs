using System;
using System.Linq;

namespace ConnectingCables
{
    class ConnectingCables
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] positions = new int[numbers.Length];

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = i + 1;
            }

            int[,] table = new int[numbers.Length + 1, positions.Length + 1];

            for (int r = 1; r < numbers.Length + 1; r++)
            {
                for (int c = 1; c < positions.Length + 1; c++)
                {
                    if (numbers[r - 1] == positions[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }
            ;
            Console.WriteLine($"Maximum pairs connected: {table[numbers.Length, positions.Length]}");
        }
    }
}
