using System;
using System.Collections.Generic;
using System.Linq;

namespace SumLimitedCoins
{
    class SumLimitedCoins
    {
        static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int target = int.Parse(Console.ReadLine());

            Dictionary<int, int> sums = GetSums(coins);

            Console.WriteLine(sums[target]);
        }

        private static Dictionary<int, int> GetSums(int[] coins)
        {
            Dictionary<int, int> result = new Dictionary<int, int> { { 0, 1 } };

            foreach (var coin in coins)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    int newSum = sum + coin;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, 1);
                    }
                    else
                    {
                        result[newSum] += 1;
                    }
                }
            }

            return result;
        }
    }
}
