using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"^([A-Aa-z]+[A-Za-z_\-\.]*[A-Za-z]+)@([A-Za-z]+[A-Za-z\.\-]+\.+[A-Za-z]+)";
            Regex regex = new Regex(pattern);

            foreach (var item in input)
            {
                if (regex.IsMatch(item))
                {
                    Match current = regex.Match(item);
                    Console.WriteLine(current.Groups[1].Value + "@" + current.Groups[2].Value);
                }
            }
        }
    }
}
