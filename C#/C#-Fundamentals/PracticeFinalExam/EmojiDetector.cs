using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string numPattern = @"\d";
            string pattern = @"::([A-Z][a-z]{2,})::|\*\*([A-Z][a-z]{2,})\*\*";
            Regex num = new Regex(numPattern);
            Regex regex = new Regex(pattern);
            MatchCollection nums = num.Matches(input);
            MatchCollection names = regex.Matches(input);

            BigInteger sum = new BigInteger();
            sum = 1;
            Dictionary<string, int> result = new Dictionary<string, int>();


            foreach (Match item in nums)
            {
                sum *= int.Parse(item.Value);
            }

            foreach (Match item in names)
            {
                string name = item.Value;
                int calculated = 0;

                for (int i = 2; i < name.Length - 2; i++)
                {
                    int value = Convert.ToInt32(name[i]);
                    calculated += value;
                }

                if (!result.ContainsKey(name))
                {
                    result.Add(name, calculated);
                }

            }

            Console.WriteLine($"Cool threshold: {sum}");
            Console.WriteLine($"{result.Count} emojis found in the text. The cool ones are:");

            foreach (var item in result)
            {
                if (item.Value > sum)
                {
                    Console.WriteLine($"{item.Key}");
                }
            }

        }
    }
}
