using System;
using System.Linq;

namespace Garden
{
    class Garden
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] garden = new int[dimentions[0], dimentions[1]];

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                int[] flowerData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int targetRow = flowerData[0];
                int targetCol = flowerData[1];

                if (targetCol >= garden.GetLength(1) || targetRow >= garden.GetLength(0))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int row = 0; row < garden.GetLength(0); row++)
                    {

                        for (int col = 0; col < garden.GetLength(1); col++)
                        {
                            if (row == targetRow && col == targetCol)
                            {
                                garden[row, col]++;
                            }
                            else if (row == targetRow)
                            {
                                garden[row, col]++;
                            }
                            else if (col == targetCol)
                            {
                                garden[row, col]++;
                            }

                        }
                    }
                }

                command = Console.ReadLine();
            }
            ;
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }

                Console.WriteLine();
            }

            ;
        }
    }
}
