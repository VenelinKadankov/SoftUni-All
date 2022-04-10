using System;
using System.Collections.Generic;

namespace AreasInMatrix
{
    class AreasInMatrix
    {
        private static char[,] matrix;
        private static bool[,] visited;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            matrix = ReadGraph(n, m);
            visited = new bool[n, m];
            List<Node> children = GetChildren(n, m);
            SortedDictionary<char, int> areas = new SortedDictionary<char, int>();
            int totalAreas = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }

                    char key = matrix[r, c];

                    DFS(r, c);
                    totalAreas++;

                    if (!areas.ContainsKey(key))
                    {
                        areas.Add(key, 1);
                    }
                    else
                    {
                        areas[key]++;
                    }

                }
            }

            Console.WriteLine($"Areas: {totalAreas}");
            foreach (var item in areas)
            {
                Console.WriteLine($"Letter '{item.Key}' -> {item.Value}");
            }

        }

        private static void DFS(int row, int col)
        {
            if (visited[row, col])
            {
                return;
            }

            visited[row, col] = true;

            List<Node> children = GetChildren(row, col);

            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static List<Node> GetChildren(int row, int col)
        {
            List<Node> children = new List<Node>();

            if (IsInside(row - 1, col) &&
                ISChild(row, col, row - 1, col) &&
                !IsVisited(row - 1, col))
            {
                children.Add(new Node { Row = row - 1, Col = col });
            }

            if (IsInside(row + 1, col) &&
                ISChild(row, col, row + 1, col) &&
                !IsVisited(row + 1, col))
            {
                children.Add(new Node { Row = row + 1, Col = col });
            }

            if (IsInside(row, col - 1) &&
                ISChild(row, col, row, col - 1) &&
                !IsVisited(row, col - 1))
            {
                children.Add(new Node { Row = row, Col = col - 1 });
            }

            if (IsInside(row, col + 1) &&
                ISChild(row, col, row, col + 1) &&
                !IsVisited(row, col + 1))
            {
                children.Add(new Node { Row = row, Col = col + 1 });
            }

            return children;
        }

        private static bool ISChild(int parentRow, int parentCol, int row, int col)
        {
            return matrix[parentRow, parentCol] == matrix[row, col];
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 &&
                row < matrix.GetLength(0) &&
                col >= 0 &&
                col < matrix.GetLength(1);
        }

        class Node
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }
        private static char[,] ReadGraph(int row, int col)
        {
            char[,] matrix = new char[row, col];

            for (int r = 0; r < row; r++)
            {
                string line = Console.ReadLine();

                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            return matrix;
        }
    }
}
