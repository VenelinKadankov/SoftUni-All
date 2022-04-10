using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> lines = new List<string>(n);
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            result.Add("A", new List<string>());
            result.Add("D", new List<string>());
            string firstPattern = @"[starSTAR*]";
            string pattern = @"@([A-Za-z]+)[^@\-!:>]*?:(\d+)[^@\-!:>]*?!([AD])![^@\-!:>]*?->(\d+)";
            Regex first = new Regex(firstPattern);
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                if (first.IsMatch(line))
                {
                    MatchCollection matches = first.Matches(line);
                    int count = matches.Count;
                    List<char> changed = new List<char>(line.Length);

                    for (int j = 0; j < line.Length; j++)
                    {
                        char current = line[j];
                        int num = Convert.ToInt32(current) - count;
                        char newChar = Convert.ToChar(num);
                        changed.Add(newChar);
                    }

                    string newLine = string.Join("", changed);

                    if (regex.IsMatch(newLine))
                    {
                        Match info = regex.Match(newLine);

                        if (info.Groups[3].Value == "A")
                        {
                            string attacked = info.Groups[3].Value;

                            if (!result.ContainsKey(attacked))
                            {
                                result.Add(attacked, new List<string>());
                                result[attacked].Add(info.Groups[1].Value);
                            }
                            else
                            {
                                result[attacked].Add(info.Groups[1].Value);
                            }

                        }
                        else if (info.Groups[3].Value == "D")
                        {
                            string key = info.Groups[3].Value;

                            if (!result.ContainsKey(key))
                            {
                                result.Add(key, new List<string>());
                                result[key].Add(info.Groups[1].Value);
                            }
                            else
                            {
                                result[key].Add(info.Groups[1].Value);
                            }
                        }
                    }

                   // Console.WriteLine(newLine);
                }
                else
                {


                    if (regex.IsMatch(line))
                    {
                        Match info = regex.Match(line);

                        if (info.Groups[3].Value == "A")
                        {
                            string attacked = info.Groups[3].Value;

                            if (!result.ContainsKey(attacked))
                            {
                                result.Add(attacked, new List<string>());
                                result[attacked].Add(info.Groups[1].Value);
                            }
                            else
                            {
                                result[attacked].Add(info.Groups[1].Value);
                            }

                        }
                        else if (info.Groups[3].Value == "D")
                        {
                            string key = info.Groups[3].Value;

                            if (!result.ContainsKey(key))
                            {
                                result.Add(key, new List<string>());
                                result[key].Add(info.Groups[1].Value);
                            }
                            else
                            {
                                result[key].Add(info.Groups[1].Value);
                            }
                        }
                    }
                }

            }

            var output = result.OrderBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in output)
            {
                if (item.Key == "A")
                {
                    Console.WriteLine($"Attacked planets: {item.Value.Count}");
                }
                else if (item.Key == "D")
                {
                    Console.WriteLine($"Destroyed planets: {item.Value.Count}");
                }

                var planets = item.Value.OrderBy(a => a).ToList();

                foreach (var plan in planets)
                {
                    Console.WriteLine($"-> {plan}");
                }
            }

        }
    }


}
