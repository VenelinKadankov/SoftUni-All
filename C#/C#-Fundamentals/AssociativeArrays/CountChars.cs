using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInString
{
    class CountChars
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray().ToArray();
            Dictionary<char, int> charsDictionary = new Dictionary<char, int>();

            foreach (char item in text)
            {
                if (charsDictionary.ContainsKey(item) && item != ' ')
                {
                    charsDictionary[item]++;
                }
                else if(!charsDictionary.ContainsKey(item) && item != ' ')
                {
                    charsDictionary.Add(item, 1);
                }
            }

            foreach (var item in charsDictionary)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }

        }
    }
}
