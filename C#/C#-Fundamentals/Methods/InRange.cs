using System;

namespace CharactersInRange
{
    class InRange
    {
        static void Main(string[] args)
        {
            int firstChar = (int)char.Parse(Console.ReadLine());
            int secondChar = (int)char.Parse(Console.ReadLine());

            char[] charArr = FindCharacters(firstChar, secondChar);
            Console.WriteLine(string.Join(" ", charArr));
        }

        private static char[] FindCharacters(int firstChar, int secondChar)
        {
            char[] wantedChars = new char[Math.Abs(secondChar - firstChar) - 1];
            int index = 0, beginning, end;

            if(firstChar > secondChar)
            {
                beginning = secondChar;
                end = firstChar;
            } 
            else
            {
                beginning = firstChar;
                end = secondChar; 
            }

            for (int i = beginning + 1; i < end; i++)
            {
                char current = (char)i;
                wantedChars[index] = current;
                index++;
            }

            return wantedChars;
        }
    }
}
