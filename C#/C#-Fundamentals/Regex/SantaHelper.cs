using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SantasHelper
{
    class SantaHelper
    {
        static void Main(string[] args)
        {
            int numToSubtract = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            List<string> kids = new List<string>();

            while (command != "end")
            {
                char[] chars = command.ToCharArray();
                List<char> result = new List<char>();

                foreach (var item in chars)
                {
                    int n = Convert.ToInt32(item) - numToSubtract;

                    if (n > 0)
                    {
                        char newChar = Convert.ToChar(n);
                        result.Add(newChar);
                    }

                }

                //Console.WriteLine(string.Join("", result));

                kids.Add(string.Join("", result));

                command = Console.ReadLine();
            }

            string pattern = @"@([A-Za-z]+)[^@\-!:>]*!([NG])!";
            Regex regex = new Regex(pattern);

            foreach (var item in kids)
            {
                Match kid = regex.Match(item);
                string name = kid.Groups[1].Value;
                string behaviour = kid.Groups[2].Value;

                if (behaviour == "G")
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
