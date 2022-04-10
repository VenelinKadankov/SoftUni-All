using System;
using System.Collections.Generic;
using System.Linq;

namespace DividingPresents
{
    class DividingPresents
    {
        static void Main(string[] args)
        {
            int[] presents = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<int, int> sums = GetAllSums(presents);
            int totalScore = presents.Sum();
            int bobScore = GetBobScore(sums, totalScore);
            int alanScore = totalScore - bobScore;

            List<int> alanPresents = GetPresents(sums, alanScore);


            Console.WriteLine($"Difference: {bobScore - alanScore}");
            Console.WriteLine($"Alan:{alanScore} Bob:{bobScore}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine("Bob takes the rest.");
            
        }

        private static List<int> GetPresents(Dictionary<int, int> sums, int alanScore)
        {
            var presents = new List<int>();

            while (alanScore != 0)
            {
                int present = sums[alanScore];
                presents.Add(present);
                alanScore -= present;
            }

            return presents;
        }

        private static int GetBobScore(Dictionary<int, int> sums, int totalScore)
        {
            int bobScore = (int)Math.Ceiling(totalScore / 2.0);

            while (!sums.ContainsKey(bobScore))
            {
                bobScore += 1;
            }

            return bobScore;
        }

        private static Dictionary<int, int> GetAllSums(int[] presents)
        {
            var results = new Dictionary<int, int>();
            results.Add(0, 0);

            foreach (var present in presents)
            {
                int[] sums = results.Keys.ToArray();

                foreach (var sum in sums)
                {
                    int newSum = sum + present;
                    if (!results.ContainsKey(newSum))
                    {
                        results.Add(newSum, present);
                    }
                }
            }
            return results;
        }
    }
}
