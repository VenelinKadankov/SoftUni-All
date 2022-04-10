using System;
using System.Text;

namespace Selling
{
    class Selling
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            int startRow = default;
            int startCol = default;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col].ToString();

                    if (line[col].ToString() == "S")
                    {
                        startCol = col;
                        startRow = row;
                    }
                }
            }

            string command = Console.ReadLine();
            int sum = 0;
            bool isOutside = false;

            while (sum < 50)
            {
                matrix[startRow, startCol] = "-";
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

                if (GotOutside(matrix, startRow, startCol))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {sum}");
                    isOutside = true;
                    break;
                }
                else
                {
                    if (int.TryParse(matrix[startRow, startCol], out int current))
                    {
                        sum += current;
                        matrix[startRow, startCol] = "S";
                    }
                    else if(matrix[startRow, startCol] == "O")
                    {
                        for (int row = 0; row < n; row++)
                        {

                            for (int col = 0; col < n; col++)
                            {
                                string currentElement = matrix[row, col];

                                if (currentElement == matrix[startRow, startCol] && (startRow != row || startCol != col))
                                {
                                    matrix[startRow, startCol] = "-";
                                    matrix[row, col] = "S";
                                    startRow = row;
                                    startCol = col;
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (!isOutside)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                Console.WriteLine($"Money: {sum}");
            }

            for (int row = 0; row < n; row++)
            {
                StringBuilder sb = new StringBuilder();

                for (int col = 0; col < n; col++)
                {
                    sb.Append(matrix[row, col]);
                }

                Console.WriteLine(sb.ToString());
            }
        }

        private static bool GotOutside(string[,] matrix, int startRow, int startCol)
        {
            return startCol < 0 || startCol >= matrix.GetLength(1) || startRow < 0 || startRow >= matrix.GetLength(0);
        }
    }
}
