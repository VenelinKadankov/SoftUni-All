using System;
using System.Collections.Generic;

namespace ReplaceRepeatingChars
{
    class ReplaceRepeating
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char character = text[0];
            int startIndex = 0;
            List<char> result = new List<char>(text.Length);
            result.Add(character);

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] != character)
                {
                    result.Add(text[i]);
                    character = text[i];
                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
