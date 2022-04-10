using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Race
{
    class Race
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> contenders = new Dictionary<string, int>();

            foreach (var name in names)
            {
                contenders.Add(name, 0);
            }

            string command = Console.ReadLine();
            string patternLetters = @"[A-Za-z]";
            string patternDigits = @"\d";
            Regex regex = new Regex(patternLetters);
            Regex dig = new Regex(patternDigits);

            while (command != "end of race")
            {
                MatchCollection letters = regex.Matches(command);
                MatchCollection digits = dig.Matches(command);

                int distance = 0;
                List<string> current = new List<string>();

                foreach (Match letter in letters)
                {
                    current.Add(letter.Value);
                }

                foreach (Match digit in digits)
                {
                    distance += int.Parse(digit.Value);
                }

                string name = string.Join("", current);

                if (contenders.ContainsKey(name))
                {
                    if (contenders[name] == 0)
                    {
                        contenders[name] = distance;
                    }
                    else
                    {
                        contenders[name] += distance;
                    }
                }

                command = Console.ReadLine();
            }

            Dictionary<string, int> output = contenders
                .OrderByDescending(a => a.Value)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            List<string> people = output.Keys.ToList();

            Console.WriteLine($"1st place: {people[0]}");
            Console.WriteLine($"2nd place: {people[1]}");
            Console.WriteLine($"3rd place: {people[2]}");

        }
    }
}
