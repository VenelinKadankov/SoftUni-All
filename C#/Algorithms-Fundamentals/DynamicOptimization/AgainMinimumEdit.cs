using System;

namespace AgainMinimumEdit
{
    class AgainMinimumEdit
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
                table[r, 0] = table[r - 1, 0] + delete;
            }

            for (int c = 1; c < result.Length + 1; c++)
            {
                table[0, c] = table[0, c - 1] + insert;
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
                        int del = table[r - 1,c] + delete;
                        int ins = table[r, c - 1] + insert;
                        int rep = table[r - 1, c - 1] + replace;

                        table[r, c] = Math.Min(ins, Math.Min(del, rep));
                    }
                }
            }

            ;

            int sum = table[first.Length, result.Length];

            Console.WriteLine($"Minimum edit distance: {sum}");
        }
    }
}
