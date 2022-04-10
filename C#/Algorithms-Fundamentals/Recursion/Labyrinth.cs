using System;
using System.Collections.Generic;

namespace PathsInLabyrinth
{
    class Labyrinth
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            List<char> directions = new List<char>();
            char[,] lab = new char[rows, cols];
            char direction = '\0';

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    lab[i, j] = line[j];
                }
            }

            FindPath(lab, 0, 0, directions, direction);
        }

        private static void FindPath(char[,] lab, int v1, int v2, List<char> directions, char direction)
        {
            if (IsOutside(lab, v1, v2) || 
                IsWall(lab, v1, v2) || 
                IsVisited(lab, v1, v2))
            {
                return;
            }

            directions.Add(direction);

            if (IsSolution(lab, v1, v2))
            {
                Console.WriteLine(string.Join("",directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            lab[v1, v2] = 'v';

            FindPath(lab, v1 + 1, v2, directions, 'D');
            FindPath(lab, v1 - 1, v2, directions, 'U');
            FindPath(lab, v1, v2 + 1, directions, 'R');
            FindPath(lab, v1, v2 - 1, directions, 'L');

            directions.RemoveAt(directions.Count - 1);
            lab[v1, v2] = '-';
        }

        private static bool IsSolution(char[,] lab, int v1, int v2)
        {
            return lab[v1, v2] == 'e';
        }

        private static bool IsVisited(char[,] lab, int v1, int v2)
        {
            return lab[v1, v2] == 'v';
        }

        private static bool IsWall(char[,] lab, int v1, int v2)
        {
            return lab[v1, v2] == '*';
        }

        private static bool IsOutside(char[,]lab, int v1, int v2)
        {
            return v1 < 0 || 
                v1 > lab.GetLength(0) - 1 || 
                v2 < 0 ||
                v2 > lab.GetLength(1) -1;

        }
    }
}
