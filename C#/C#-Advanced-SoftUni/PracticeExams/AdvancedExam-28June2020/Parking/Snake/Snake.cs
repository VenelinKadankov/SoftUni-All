using System;
using System.Text;

namespace Snake
{
    class Snake
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] field = new char[size, size];
            int foodCounter = 0;
            bool isOutside = false;

            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = line[col];

                    if (line[col] == 'S')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            ;
            while (foodCounter < 10)
            {
                string command = Console.ReadLine();

                field[startRow, startCol] = '.';

                switch (command)
                {
                    case "up":
                        startRow--;
                        break;
                    case "down":
                        startRow++;
                        break;
                    case "left":
                        startCol--;
                        break;
                    case "right":
                        startCol++;
                        break;
                    default:
                        break;
                }

                if (startRow < 0 || startRow >= size || startCol < 0 || startCol >= size)
                {
                    isOutside = true;
                    break;
                }

                if (field[startRow,startCol] == '*')
                {
                    foodCounter++;
                }
                else if (field[startRow, startCol] == 'B')
                {
                    field[startRow, startCol] = '.';

                    for (int row = 0; row < field.GetLength(0); row++)
                    {

                        for (int col = 0; col < field.GetLength(1); col++)
                        {

                            if (field[row, col] == 'B')
                            {
                                startRow = row;
                                startCol = col;
                            }

                        }
                    }

                }

                field[startRow, startCol] = 'S';

            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sb.Append(field[i, j]);
                }

                sb.AppendLine();
            }

            if (isOutside)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodCounter}");
            Console.WriteLine(sb.ToString());
        }
    }
}
