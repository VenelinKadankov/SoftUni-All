using System;
using System.Collections.Generic;
using System.Linq;

namespace Time
{
    class Time
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] second = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] table = new int[first.Length + 1, second.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (first[r - 1] == second[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }


            int row = first.Length - 1;
            int col = second.Length - 1;
            var stack = new Stack<int>();


            while (row > 0 && col > 0)
            {
                if (first[row] == second[col])
                {
                    stack.Push(first[row]);
                    row--;
                    col--;
                }
                else if(table[row, col + 1] > table[row + 1, col])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            while (row > 0)
            {
                if (first[row] == second[0])
                {
                    stack.Push(first[row]);
                }
                row--;
            }

            while (col > 0)
            {
                if (second[col] == first[0])
                {
                    stack.Push(second[col]);
                }
                col--;
            }

            if (first[0] == second[0])
            {
                stack.Push(first[0]);
            }
            Console.WriteLine(string.Join(" ", stack));
            Console.WriteLine(table[first.Length, second.Length]);
        }
    }
}
