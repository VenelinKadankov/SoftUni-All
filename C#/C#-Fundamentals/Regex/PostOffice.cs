using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class PostOffice
    {
        static void Main(string[] args)
        {
            string pattern1 = @"([$#%*&])([A-Z]+)\1";
            string pattern2 = @"([6-9]\d):([0-2]\d)";
            string pattern3 = @"^([A-Z])([a-z]{0,20})";
            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            Regex regexName = new Regex(pattern1);
            Regex regwxLength = new Regex(pattern2);
            Regex sameWord = new Regex(pattern3);
            List<string> potentialNames = input[2].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<char, int> posibilities = new Dictionary<char, int>();

            Match letters = regexName.Match(input[0]);
            char[] chars = letters.Groups[2].Value.ToCharArray();
            MatchCollection positionAndLength = regwxLength.Matches(input[1]);

            foreach (var item in chars)
            {
                int num = Convert.ToInt32(item);

                foreach (Match match in positionAndLength)
                {
                    int position = int.Parse(match.Groups[1].Value);
                    int length = int.Parse(match.Groups[2].Value);

                    if (num == position && length > 0 && length < 20 && !posibilities.ContainsKey(item))
                    {
                        posibilities.Add(item, length + 1);
                    }
                }
            }

            // foreach (var item in potentialNames)
            // {
            //   Match some = sameWord.Match(item);
            //     char first = item[0];

            //     if (posibilities.ContainsKey(first))
            //     {
            //         if (posibilities[first] == item.Length)
            //         {

            //           Console.WriteLine(item);
            //       }
            //   }
            // }

            foreach (var item in posibilities)
            {
                char first = item.Key;
                int length = item.Value;

                var isThere = potentialNames.Any(a => a[0] == first && a.Length == length);

                if (isThere)
                {
                    var result = potentialNames.Find(a => a[0] == first && a.Length == length);
                    Console.WriteLine(result);
                }

            }
        }
    }
}
