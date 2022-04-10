using System;
using System.Collections.Generic;

namespace BinomilCoefficients
{
    class BinomialCoefficients
    {
        private static Dictionary<string, long> memo;

        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            memo = new Dictionary<string, long>();

            long sum = GetBinom(row, col);
            Console.WriteLine(sum);
        }

        private static long GetBinom(int row, int col)
        {
            string place = $"{row} {col}";

            if (memo.ContainsKey(place))
            {
                return memo[place];
            }
            if (col == 0 || col == row)
            {
                return 1;
            }

            long sum = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            memo.Add(place, sum);

            return sum;

        }
    }
}
