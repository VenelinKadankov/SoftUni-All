using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([=\/])([A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);
            int sum = 0;
            List<string> locations = new List<string>();

            if (regex.IsMatch(text))
            {
                MatchCollection matches = regex.Matches(text);

                foreach (Match match in matches)
                {
                    locations.Add(match.Groups[2].Value);
                    sum += match.Groups[2].Value.Length;
                }
            }

            Console.WriteLine($"Destinations: {string.Join(", ", locations)}");
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}
