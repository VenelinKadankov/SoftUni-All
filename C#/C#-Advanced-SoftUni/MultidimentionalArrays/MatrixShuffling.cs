using System;
using System.Linq;
using System.Text;

namespace MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimentions[0], dimentions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            string command = Console.ReadLine();

            while (command?.ToUpper() != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0]?.ToUpper() != "SWAP" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int firstRow = int.Parse(tokens[1]);
                    int firstCol = int.Parse(tokens[2]);
                    int secondRow = int.Parse(tokens[3]);
                    int secondCol = int.Parse(tokens[4]);

                    if (firstRow < 0 || secondRow < 0 || firstRow >= matrix.GetLength(0) || secondRow >= matrix.GetLength(0) ||
                        firstCol < 0 || secondCol < 0 || firstCol >= matrix.GetLength(1) || secondCol >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string temp = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            StringBuilder currentLine = new StringBuilder();
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                currentLine.Append($"{matrix[row, col]} ");
                            }
                            Console.WriteLine(currentLine.ToString());
                        }
                    }
                }

                command = Console.ReadLine();
            }

        }
    }
}
