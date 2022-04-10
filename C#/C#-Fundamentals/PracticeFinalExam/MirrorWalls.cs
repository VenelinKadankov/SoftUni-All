using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MirrorWalls
{
    class MirrorWalls
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string pattern = @"([@#])([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(message))
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                MatchCollection matches = regex.Matches(message);
                List<string> result = new List<string>();
                //Dictionary<string, string> result = new Dictionary<string, string>();


                foreach (Match match in matches)
                {
                    string first = match.Groups[2].Value;
                    string second = match.Groups[3].Value;
                    char[] chars = second.ToCharArray();
                    Array.Reverse(chars);
                    string mirror = new string(chars);

                    if (first == mirror)
                    {
                        result.Add($"{first} <=> {second}");
                    }
                }

                Console.WriteLine($"{matches.Count} word pairs found!");
                if (result.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", result));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }

            }
        }
    }
}
