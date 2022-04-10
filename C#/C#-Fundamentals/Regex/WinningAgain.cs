using System;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class WinnigTicket
    {
        static void Main(string[] args)
        {
            //string splitPattern = @"\s*,+\s*|\s+";
            //string[] tickets = Regex.Split(Console.ReadLine(), splitPattern);
            string[] tickets = Console.ReadLine().Split(new string[] { ",", ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"[$]{6,}|[@]{6,}|[#]{6,}|[\^]{6,}";
            Regex regex = new Regex(pattern);

            if (tickets.Length != 0)
            {


                foreach (var item in tickets)
                {

                    if (item.Length != 20)
                    {
                        Console.WriteLine("invalid ticket");
                    }
                    else
                    {
                        string left = item.Substring(0, 10);
                        string right = item.Substring(10);

                        if (regex.IsMatch(left) && regex.IsMatch(right))
                        {
                            Match matchLeft = regex.Match(left);
                            Match matchRight = regex.Match(right);

                            if (matchLeft.Value == matchRight.Value && matchRight.Value.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{item}\" - {matchLeft.Length}{matchLeft.Value[1]} Jackpot!");
                            }
                            else if (matchLeft.Value == matchRight.Value)
                            {
                                Console.WriteLine($"ticket \"{item}\" - {matchRight.Length}{matchLeft.Value[1]}");
                            }
                            else if (matchRight.Value[1] == matchLeft.Value[1])
                            {
                                Console.WriteLine($"ticket \"{item}\" - {Math.Min(matchLeft.Length, matchRight.Length)}{matchLeft.Value[1]}");

                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{item}\" - no match");
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
    }
}

