using System;

namespace MinimumEditDistance
{
    class MinimumEditDistance
    {
        static void Main(string[] args)
        {
            int replace = int.Parse(Console.ReadLine());
            int insert = int.Parse(Console.ReadLine());
            int delete = int.Parse(Console.ReadLine());
            string first = Console.ReadLine();
            string result = Console.ReadLine();

            int[,] table = new int[first.Length + 1, result.Length + 1];

            for (int r = 1; r < first.Length + 1; r++)
            {
                table[r, 0] = r;
            }

            for (int c = 1; c < result.Length + 1; c++)
            {
                table[0, c] = c;
            }


            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (first[r - 1] == result[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1];
                    }
                    else
                    {
                        table[r, c] = Math.Min(table[r - 1, c], table[r, c - 1]) + 1;
                    }
                }
            }

            int points = 0;
            int operations = table[first.Length, result.Length];

            // if (operations != 0)
            //   {
            if (first.Length >= result.Length)
            {
                if (replace > insert + delete)
                {
                    int diff = first.Length - result.Length;
                    points += diff * delete;
                    operations -= diff;
                    points += (operations / 2) * (insert + delete);
                }
                else
                {

                    int diff = first.Length - result.Length;
                    points += diff * delete;
                    operations -= diff;
                    points += (operations / 2) * replace;
                }

            }
            else
            {
                if (replace >= insert + delete)
                {
                    int diff = result.Length - first.Length;
                    points += diff * insert;
                    operations -= diff;
                    points += (operations / 2) * (insert + delete);
                }
                else if(replace < insert + delete)
                {
                    int diff = result.Length - first.Length;
                    points += diff * delete;
                    operations -= diff;
                    points += (operations / 2) * replace;
                }

            ;
            }
            //}
            Console.WriteLine($"Minimum edit distance: {points}");
        }

        private static bool HasCommonIndexes(string first, string second)
        {
            bool isSame = false;

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                if (first[i] == second[i])
                {
                    isSame = true;
                }
            }

            return isSame;
        }
    }
}
