using System;
using System.Text;

namespace Bee
{
    class Bee
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] garden = new char[size, size];
            int startRow = -1;
            int startCol = -1;
            bool isLost = false;

            int flowerCounter = 0;

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < line.Length; col++)
                {
                    garden[row, col] = line[col];

                    if (garden[row,col] == 'B')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command?.ToUpper() != "END")
            {
                garden[startRow, startCol] = '.';

                int lastRow = startRow;
                int lastCol = startCol;


                if (command?.ToUpper() == "UP")
                {
                    startRow--;
                }
                else if (command?.ToUpper() == "DOWN")
                {
                    startRow++;
                }
                else if (command?.ToUpper() == "RIGHT")
                {
                    startCol++;
                }
                else if (command?.ToUpper() == "LEFT")
                {
                    startCol--;
                }


                if (startRow < 0 || startCol < 0 || startRow >= size || startCol >= size)
                {
                    isLost = true;
                    break;
                }


                if (garden[startRow, startCol] == 'f')
                {
                    flowerCounter++;
                    garden[startRow, startCol] = 'B';
                }
                else if (garden[startRow, startCol] == 'O')
                {
                    garden[startRow, startCol] = 'B';
                    continue;
                }


                command = Console.ReadLine();

                if (command?.ToUpper() == "END")
                {
                    garden[startRow, startCol] = 'B';
                    //startRow = lastRow;
                    //startCol = lastCol;
                }
            }
            ;

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (flowerCounter >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowerCounter} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowerCounter} flowers more");
            }

            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    sb.Append(garden[row, col]);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
