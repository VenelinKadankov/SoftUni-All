using System;
using System.Linq;

namespace SumWithUnlimitedCoins
{
    class SumCoins
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int target = int.Parse(Console.ReadLine());

            int count = GetCount(coins, target);
            Console.WriteLine(count);
        }

        private static int GetCount(int[] coins, int target)
        {
            int[] sums = new int[target + 1];
            sums[0] = 1;

            foreach (var coin in coins)
            {
                for (int i = coin; i < sums.Length; i++)
                {
                    sums[i] += sums[i - coin];
                }
            }

            return sums[target];
        }
    }
}
