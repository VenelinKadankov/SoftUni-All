using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            char[,] table = new char[dimention, dimention];

            for (int row = 0; row < table.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < table.GetLength(1); col++)
                {
                    table[row, col] = line[col];
                }
            }

            int knightsToRemove = 0;

            while (true)
            {
                int mostHits = 0;
                int mostHitsRow = -1;
                int mostHitsCol = -1;

                for (int row = 0; row < table.GetLength(0); row++)
                {
                    for (int col = 0; col < table.GetLength(1); col++)
                    {
                        char ch = table[row, col];

                        if (ch == 'K')
                        {
                            int counter = FindDependencies(row, col, table);

                            if (mostHits < counter)
                            {
                                mostHits = counter;
                                mostHitsRow = row;
                                mostHitsCol = col;
                            }
                        }

                    }
                }

                if (mostHits == 0)
                {
                    break;
                }

                table[mostHitsRow, mostHitsCol] = '0';
                knightsToRemove++;

            }

            Console.WriteLine(knightsToRemove);

        }

        private static int FindDependencies(int row, int col, char[,] table)
        {
            int counter = 0;

            if (row - 2 >= 0 && col - 1 >= 0 && table[row - 2, col - 1] == 'K')
            {
                counter++;
            }

            if (row - 2 >= 0 && col + 1 < table.GetLength(1) && table[row - 2, col + 1] == 'K')
            {
                counter++;
            }

            if (row - 1 >= 0 && col - 2 >= 0 && table[row - 1, col - 2] == 'K')
            {
                counter++;
            }

            if (row - 1 >= 0 && col + 2 < table.GetLength(1) && table[row - 1, col + 2] == 'K')
            {
                counter++;
            }

            if (row + 2 < table.GetLength(0) && col - 1 >= 0 && table[row + 2, col - 1] == 'K')
            {
                counter++;
            }

            if (row + 2 < table.GetLength(0) && col + 1 < table.GetLength(1) && table[row + 2, col + 1] == 'K')
            {
                counter++;
            }

            if (row + 1 < table.GetLength(0) && col - 2 >= 0 && table[row + 1, col - 2] == 'K')
            {
                counter++;
            }

            if (row + 1 < table.GetLength(0) && col + 2 < table.GetLength(1) && table[row + 1, col + 2] == 'K')
            {
                counter++;
            }

            return counter;
        }
    }
}
