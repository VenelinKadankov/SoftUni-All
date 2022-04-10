using System;
using System.Collections.Generic;

namespace TwoMinutesToMidnight
{
    class TwoMinutesToMidnight
    {
        private static Dictionary<string, long> memo;
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            memo = new Dictionary<string, long>();

            long result = GetBinom(k, n);
            Console.WriteLine(result);
        }

        private static long GetBinom(int row, int col)
        {
            string id = $"{row} {col}";

            if (memo.ContainsKey(id))
            {
                return memo[id];
            }
            if (col == 0 || row == col)
            {
                return 1;
            }

            long result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            memo[id] = result;
            return result;
        }
    }
}
