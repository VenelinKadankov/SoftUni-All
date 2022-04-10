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
            Dictionary<char, List<int>> constrains = new Dictionary<char, List<int>>();

            Match letters = regexName.Match(input[0]);
            char[] chars = letters.Groups[2].Value.ToCharArray();
            MatchCollection positionAndLength = regwxLength.Matches(input[1]);

            foreach (var item in chars)
            {
                int num = Convert.ToInt32(item);

                foreach (Match match in positionAndLength)
                {
                    int position = int.Parse(match.Groups[1].Value);
                    int length = int.Parse(match.Groups[2].Value) + 1;

                    if (num == position && length > 0 && length <= 21 && !constrains.ContainsKey(item))
                    {
                        constrains.Add(item, new List<int>());
                        constrains[item].Add(length);
                    }
                    else if (num == position && length > 0 && length <= 20 && constrains.ContainsKey(item))
                    {
                        constrains[item].Add(length);
                    }
                }
            }

            foreach (var item in potentialNames)
            {

                Match word = sameWord.Match(item);
                char first = word.Groups[0].Value[0];

                if (constrains.ContainsKey(first) && int.Parse(word.Groups[2].Value) == constrains[first][0])
                {
                    Console.WriteLine(item);
                }

               // if (constrains.ContainsKey(item[0]))
               // {
               //
                 //   foreach (var line in constrains)
                //    {
                //        if (item[0] == line.Key && line.Value.Contains(item.Length))
                //        {
                //            Console.WriteLine(item);
                //        }
                 //   }


              //  }
            }
        }
    }
}
