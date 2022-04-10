using System;
using System.Collections.Generic;

namespace Miner
{
    class Miner
    {
        private static int startRow;
        private static int startCol;
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            char[,] field = new char[size, size];
            int startRow = -1;
            int startCol = -1;
            bool isOver = false;
            int coalCollected = 0;
            int totalCoal = 0;
            bool allIsCollected = false;

            for (int row = 0; row < field.GetLength(1); row++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (line[col] == "s")
                    {
                        startRow = row;
                        startCol = col;
                    }

                    if (line[col] == "c")
                    {
                        totalCoal++;
                    }

                    field[row, col] = line[col][0];
                }

            }

            while (commands.Count > 0)
            {
                string command = commands.Dequeue();

                if (IsInField(field, command, startRow, startCol))
                {
                    if (command == "up")
                    {
                        startRow--;
                    }
                    else if (command == "down")
                    {
                        startRow++;
                    }
                    else if (command == "left")
                    {
                        startCol--;
                    }
                    else if (command == "right")
                    {
                        startCol++;
                    }



                    if (field[startRow, startCol] == 'e')
                    {
                        isOver = true;
                        break;
                    }
                    else if (field[startRow, startCol] == 'c')
                    {
                        coalCollected++;
                        field[startRow, startCol] = '*';

                        if (coalCollected == totalCoal)
                        {
                            allIsCollected = true;
                            break;
                        }
                    }

                }

            }

            if (isOver)
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
            }
            else if (allIsCollected)
            {
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoal - coalCollected} coals left. ({startRow}, {startCol})");
            }

        }

        private static bool IsInField(char[,] field, string command, int startRow, int startCol)
        {
            if (command == "up")
            {
                if (startRow - 1 < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (command == "down")
            {
                if (startRow + 1 >= field.GetLength(0))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (command == "left")
            {
                if (startCol - 1 < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (command == "right")
            {
                if (startCol + 1 >= field.GetLength(1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
