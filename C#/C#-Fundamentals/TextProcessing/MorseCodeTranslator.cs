using System;
using System.Collections.Generic;

namespace MorseCodeTranslator
{
    class MorseCodeTranslator
    {
        static void Main(string[] args)
        {
            string[] morse = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, char> dict = new Dictionary<string, char>();
            List<char> output = new List<char>();

            dict.Add(".-", 'A');
            dict.Add("-...", 'B');
            dict.Add("-.-.", 'C');
            dict.Add("-..", 'D');
            dict.Add(".", 'E');
            dict.Add("..-.", 'F');
            dict.Add("--.", 'G');
            dict.Add("....", 'H');
            dict.Add("..", 'I');
            dict.Add(".---", 'J');
            dict.Add("-.-", 'K');
            dict.Add(".-..", 'L');
            dict.Add("--", 'M');
            dict.Add("-.", 'N');
            dict.Add("---", 'O');
            dict.Add(".--.", 'P');
            dict.Add("--.-", 'Q');
            dict.Add(".-.",'R');
            dict.Add("...", 'S');
            dict.Add("-", 'T');
            dict.Add("..-", 'U');
            dict.Add("...-", 'V');
            dict.Add(".--", 'W');
            dict.Add("-..-", 'X');
            dict.Add("-.--", 'Y');
            dict.Add("--..", 'Z');

            for (int i = 0; i < morse.Length; i++)
            {
                string current = morse[i];

                if (current == "|")
                {
                    output.Add(' ');
                }
                else
                {
                    output.Add(dict[current]);
                }
            }

            Console.WriteLine(string.Join("", output));
        }
    }
}
