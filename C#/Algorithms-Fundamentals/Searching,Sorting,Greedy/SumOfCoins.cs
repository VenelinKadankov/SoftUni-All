using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumOfCoins
{
    class SumOfCoins
    {
        static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int target = int.Parse(Console.ReadLine());
            int count = 0;
            StringBuilder sb = new StringBuilder();

            coins = coins.OrderByDescending(a => a).ToList();

            while (target > 0 && coins.Count > 0)
            {
                int currentCoin = coins[0];
                coins.RemoveAt(0);
                if (currentCoin > target)
                {
                    continue;
                }
                int countCurrent = target / currentCoin;
                count += countCurrent;
                target -= countCurrent * currentCoin;
                sb.AppendLine($"{countCurrent} coin(s) with value {currentCoin}");
            }

            if (target > 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {count}");
                Console.WriteLine(sb.ToString());
            }

        }
    }
}
