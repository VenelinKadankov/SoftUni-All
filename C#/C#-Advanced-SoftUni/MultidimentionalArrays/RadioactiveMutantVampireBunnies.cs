using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[dimentions[0], dimentions[1]];
            int startRow = -1;
            int startCol = -1;
            List<int[]> bunnies = new List<int[]>();
            bool isWon = false;
            bool isLost = false;
            int[] lostCoor = new int[2];

            for (int row = 0; row < dimentions[0]; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < dimentions[1]; col++)
                {
                    matrix[row, col] = line[col];


                    if (line[col] == 'B')
                    {
                        int[] bunniCoordinates = new int[2] { row, col };
                        bunnies.Add(bunniCoordinates);
                    }

                    if (line[col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];

                if (IsSafe(matrix, startRow, startCol, command))
                {
                    matrix[startRow, startCol] = '.';
                    PopulateWithBunnies(matrix, bunnies);
                    isWon = true;
                    break;
                }

                if (IsBunny(matrix, startRow, startCol, command))
                {
                    PopulateWithBunnies(matrix, bunnies);
                    lostCoor = StepBack(startRow, startCol, command);
                    startRow = lostCoor[0];
                    startCol = lostCoor[1];
                    isLost = true;
                    break;
                }


                switch (command)
                {
                    case 'L':
                        matrix[startRow, startCol] = '.';
                        startCol--;
                        matrix[startRow, startCol] = 'P';
                        break;
                    case 'R':
                        matrix[startRow, startCol] = '.';
                        startCol++;
                        matrix[startRow, startCol] = 'P';
                        break;
                    case 'U':
                        matrix[startRow, startCol] = '.';
                        startRow--;
                        matrix[startRow, startCol] = 'P';
                        break;
                    case 'D':
                        matrix[startRow, startCol] = '.';
                        startRow++;
                        matrix[startRow, startCol] = 'P';
                        break;
                    default:
                        break;
                }


                PopulateWithBunnies(matrix, bunnies);

                if (!ContainsPlayer(matrix))
                {
                    isLost = true;
                    break;
                }

                bunnies = CreateNewListBunnies(matrix);
            }

            PrintResult(matrix, startRow, startCol, isWon, isLost); //, lostCoor);
        }

        private static void PrintResult(char[,] matrix, int startRow, int startCol, bool isWon, bool isLost)//, int[] lostCoor)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            if (isWon)
            {
                Console.WriteLine($"won: {startRow} {startCol}");
            }
            else if (isLost)
            {
                Console.WriteLine($"dead: {startRow} {startCol}");
            }
        }

        private static bool ContainsPlayer(char[,] matrix)
        {
            bool containsP = false;
            foreach (var item in matrix)
            {
                if (item == 'P')
                {
                    containsP = true;
                }
            }

            return containsP;
        }

        private static int[] StepBack(int startRow, int startCol, char command)
        {
            switch (command)
            {
                case 'U':
                    startRow--;
                    break;
                case 'D':
                    startRow++;
                    break;
                case 'L':
                    startCol--;
                    break;
                case 'R':
                    startCol++;
                    break;
                default:
                    break;
            }

            int[] coor = new int[] { startRow, startCol };
            return coor;
        }

        private static List<int[]> CreateNewListBunnies(char[,] matrix)
        {
            List<int[]> newListBunnies = new List<int[]>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        int[] coordinates = new int[2] { row, col };
                        newListBunnies.Add(coordinates);
                    }
                }
            }

            return newListBunnies;
        }

        private static void PopulateWithBunnies(char[,] matrix, List<int[]> bunnies)
        {
            foreach (var item in bunnies)
            {
                int row = item[0];
                int col = item[1];


                if (row - 1 >= 0)
                {
                    matrix[row - 1, col] = 'B';
                }

                if (row + 1 < matrix.GetLength(0))
                {
                    matrix[row + 1, col] = 'B';
                }

                if (col - 1 >= 0)
                {
                    matrix[row, col - 1] = 'B';
                }

                if (col + 1 < matrix.GetLength(1))
                {
                    matrix[row, col + 1] = 'B';
                }


            }
        }

        private static bool IsBunny(char[,] matrix, int startRow, int startCol, char command)
        {
            if (command == 'L' && matrix[startRow, startCol - 1] == 'B')
            {
                return true;
            }
            if (command == 'R' && matrix[startRow, startCol + 1] == 'B')
            {
                return true;
            }
            if (command == 'U' && matrix[startRow - 1, startCol] == 'B')
            {
                return true;
            }
            if (command == 'D' && matrix[startRow + 1, startCol] == 'B')
            {
                return true;
            }

            return false;
        }

        private static bool IsSafe(char[,] matrix, int startRow, int startCol, char command)
        {
            if (command == 'L' && startCol - 1 < 0)
            {
                return true;
            }
            if (command == 'R' && startCol + 1 >= matrix.GetLength(1))
            {
                return true;
            }
            if (command == 'U' && startRow - 1 < 0)
            {
                return true;
            }
            if (command == 'D' && startRow + 1 >= matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }
    }
}
