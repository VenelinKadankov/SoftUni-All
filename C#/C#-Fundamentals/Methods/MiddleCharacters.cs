using System;

namespace MiddleCharacters
{
    class MiddleCharacters
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            FindMiddleCharacter(line);

        }

         static void FindMiddleCharacter(string text)
        {
            if (text.Length % 2 == 1)
            {
                Console.WriteLine(text[text.Length / 2]);
            }
            else
            {
                Console.WriteLine("" + text[text.Length / 2 - 1] + text[text.Length / 2]);
            }

        }
    }
}
