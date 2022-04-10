using System;

namespace DecryptingMessages
{
    class Decrypting
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            char[] characters = new char[lines];

            for (int i = 0; i < lines; i++)
            {
                char givenChar = char.Parse(Console.ReadLine());
                int charNum = (int)givenChar + key;
                characters[i] = (char)charNum;

            }

            string result = string.Join("", characters);
            Console.WriteLine(result);
            //Console.WriteLine(new string(characters));
        }
    }
}
