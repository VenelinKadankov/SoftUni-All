using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuick
{
    class RageQuick
    {
        static void Main(string[] args)
        {
            string commands = Console.ReadLine().ToUpper();
            string pattern = @"([\D]+)(\d+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(commands);
            StringBuilder sb = new StringBuilder();
            int counter = 0;

            foreach (Match item in matches)
            {
                string symbols = item.Groups[1].Value.ToUpper();
                int count = int.Parse(item.Groups[2].Value);

                for (int i = 0; i < count; i++)
                {
                    sb.Append(symbols.ToUpper());
                }

            }

            counter = sb.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {counter}");
            Console.WriteLine($"{sb}");
        }
    }
}
