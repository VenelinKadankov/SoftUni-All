using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> deamons = new Dictionary<string, List<double>>();
            List<char> operands = new List<char>();
            string patternDelimiters = @",+\s*";
            string[] input = Regex.Split(Console.ReadLine(), patternDelimiters);
            //string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string patternText = @"[^+\-*\/\.0-9]";
            string operandsPattern = @"[\*\/]";
            string patternDigit = @"[-+]?\d\.?\d?";
            Regex regexLetters = new Regex(patternText);
            Regex regexDigit = new Regex(patternDigit);
            Regex regexOperands = new Regex(operandsPattern);

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];
                List<char> player = new List<char>();
                List<double> power = new List<double>();
                int health = 0;
                double pow = 0.0;

                if (regexLetters.IsMatch(current))
                {
                    MatchCollection chars = regexLetters.Matches(current);
                    MatchCollection digs = regexDigit.Matches(current);
                    MatchCollection opers = regexOperands.Matches(current);
                   


                    foreach (Match item in chars)
                    {
                        char some = Convert.ToChar(item.Value);
                        int n = Convert.ToInt32(some);
                        health += n;
                    }

                    foreach (Match item in digs)
                    {
                        pow += Double.Parse(item.Value);
                    }

                    foreach (Match item in opers)
                    {
                        if (item.Value == "/")
                        {
                            pow /= 2;
                        }
                        else
                        {
                            pow *= 2;
                        }
                       
                    }

                   
                    deamons.Add(current, new List<double>());
                    deamons[current].Add(health);
                    deamons[current].Add(pow);
                }

            }

            var output = deamons.OrderBy(a => a.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var item in output)
            {
                List<double> atributes = item.Value;
                Console.WriteLine($"{item.Key} - {item.Value[0]} health, {item.Value[1]:F2} damage");

            }
        }
    }
}
