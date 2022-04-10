using System;
using System.Linq;

namespace Mario
{
    class Mario
    {
        static void Main(string[] args)
        {
            var lives = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());
            var firstRow = Console.ReadLine();

            var row = -1;
            var col = -1;
            var maze = new char[rows, firstRow.Length];
            var isDead = false;
            var isWon = false;

            for (int r = 0; r < rows; r++)
            {
                if (r != 0)
                {
                    firstRow = Console.ReadLine();
                }

                for (int c = 0; c < maze.GetLength(1); c++)
                {
                    maze[r, c] = firstRow[c];

                    if (maze[r, c] == 'M')
                    {
                        row = r;
                        col = c;
                    }
                }
            }

            while (lives > 0)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var command = tokens[0][0];

                var bowserRow = int.Parse(tokens[1]);
                var bowserCol = int.Parse(tokens[2]);

                maze[bowserRow, bowserCol] = 'B';

                maze[row, col] = '-';

                row = GetMarioRow(row, command);
                col = GetMarioCol(col, command);

                row = CheckRowValidity(row, maze);
                col = CheckColValidity(col, maze);

                lives -= 1;

                if (lives <= 0)
                {
                    maze[row, col] = 'X';
                    isDead = true;

                    break;
                }

                if (maze[row, col] == 'B')
                {
                    lives -= 2;

                    if (lives <= 0)
                    {
                        maze[row, col] = 'X'; // is id B or X
                        isDead = true;

                        break;
                    }
                }

                if (maze[row, col] == 'P')
                {
                    isWon = true;
                    maze[row, col] = '-';

                    break;
                }

                maze[row, col] = 'M';
            }

            if (isDead)
            {
                Console.WriteLine($"Mario died at {row};{col}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            for (int r = 0; r < maze.GetLength(0); r++)
            {
                for (int c = 0; c < maze.GetLength(1); c++)
                {
                    Console.Write(maze[r, c]);
                }

                Console.WriteLine();
            }
        }

        private static int GetMarioRow(int currentRow, char command)
        {
            if (command == 'W')
            {
                currentRow -= 1;
            }
            else if (command == 'S')
            {
                currentRow += 1;
            }

            return currentRow;
        }

        private static int GetMarioCol(int currentCol, char command)
        {
            if (command == 'A')
            {
                currentCol -= 1;
            }
            else if (command == 'D')
            {
                currentCol += 1;
            }

            return currentCol;
        }

        private static int CheckRowValidity(int row, char[,] maze)
        {
            if (row < 0)
            {
                return 0;
            }
            else if(row >= maze.GetLength(0))
            {
                return maze.GetLength(0) - 1;
            }

            return row;
        }

        private static int CheckColValidity(int col, char[,] maze)
        {
            if (col < 0)
            {
                return 0;
            }
            else if (col >= maze.GetLength(1))
            {
                return maze.GetLength(0) - 1;
            }

            return col;
        }
    }
}
