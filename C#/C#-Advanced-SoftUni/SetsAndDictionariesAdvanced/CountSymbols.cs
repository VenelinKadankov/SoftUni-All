using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> chars = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!chars.ContainsKey(text[i]))
                {
                    chars.Add(text[i], 0);
                }

                chars[text[i]]++;
            }

            var result = chars.OrderBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
