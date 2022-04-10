using System;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class WinnigTicket
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new string[] { ",", ", ", " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"([$@#^]{6,10}).*?([$@#^]{6,10})";
            Regex regex = new Regex(pattern);

            foreach (var item in tickets)
            {
                if (item.Length < 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else if (regex.IsMatch(item))
                {
                    Match match = regex.Match(item);


                    int endLeft = item.IndexOf(match.Groups[1].Value) + match.Groups[1].Value.Length - 1;
                    int beginningRight = item.LastIndexOf(match.Groups[2].Value);

                    if (endLeft >= item.Length / 2 || beginningRight < item.Length / 2)
                    {
                        Console.WriteLine($"ticket \"{item}\" - no match");
                    }
                    else if(match.Groups[1].Value.Length == match.Groups[2].Value.Length && match.Groups[1].Value.Length != 10)
                    {
                        Console.WriteLine($"ticket \"{item}\" - {match.Groups[1].Value.Length}{match.Groups[1].Value[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{item}\" - {match.Groups[1].Value.Length}{match.Groups[1].Value[1]} Jackpot!");

                    }

                }
                else
                {
                    Console.WriteLine($"ticket \"{item}\" - no match");
                }
            }
        }
    }
}
