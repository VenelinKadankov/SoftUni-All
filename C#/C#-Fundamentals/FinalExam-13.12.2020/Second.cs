using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"([\*@])([A-Z][a-z]{2,})\1: \[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                if (regex.IsMatch(text))
                {
                    Match match = regex.Match(text);
                    string message = match.Groups[2].Value;
                    char[] one = match.Groups[3].Value.ToCharArray();
                    char[] two = match.Groups[4].Value.ToCharArray();
                    char[] three = match.Groups[5].Value.ToCharArray();
                    int first = Convert.ToInt32(one[0]);
                    int second = Convert.ToInt32(two[0]);
                    int third = Convert.ToInt32(three[0]);

                    Console.WriteLine($"{message}: {first} {second} {third}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }

        }
    }
}
