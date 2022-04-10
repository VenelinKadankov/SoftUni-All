using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectAreasMatrix
{
    class ConnectAreas
    {
        public static bool[,] used;
        public static char[,] matrix;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            used = new bool[rows, cols];

            CreeateMatrix(rows);

            List<Area> areas = new List<Area>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '*')
                    {
                        continue;
                    }
                    if (used[i, j])
                    {
                        continue;
                    }

                    var areaSize = GetSize(matrix, i, j, used);
                    var area = new Area { Row = i, Col = j, Size = areaSize };
                    areas.Add(area);

                }


            }

            var result = areas.OrderByDescending(a => a.Size)
                              .ThenBy(a => a.Row)
                              .ThenBy(a => a.Col)
                              .ToList();
            Console.WriteLine($"Total areas found: {areas.Count}");
            for (int k = 0; k < result.Count; k++)
            {
                var current = result[k];
                Console.WriteLine($"Area #{k + 1} at ({current.Row}, {current.Col}), size: {current.Size}");
            }
        }

        private static int GetSize(char[,] matrix, int row, int col, bool[,] used)
        {
            if (IsOutside(row, col))
            {
                return 0;
            }
            if (matrix[row, col] == '*')
            {
                return 0;
            }
            if (used[row, col])
            {
                return 0;
            }

            used[row, col] = true;
            return 1 + GetSize(matrix, row + 1, col, used) +
                GetSize(matrix, row - 1, col, used) +
                GetSize(matrix, row, col + 1, used) +
                GetSize(matrix, row, col - 1, used);
        }

        private static void CreeateMatrix(int rows)
        {
            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine();
                for (int c = 0; c < line.Length; c++)
                {
                    matrix[r, c] = line[c];
                }
            }
        }


        private static bool IsOutside(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        class Area
        {
            public int Size { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }
        }
    }
}
