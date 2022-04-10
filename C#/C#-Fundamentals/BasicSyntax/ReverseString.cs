using System;

namespace ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string givenWord = Console.ReadLine();

            static string Reverse(string givenWord)
            {
                char[] changedWord = givenWord.ToCharArray();
                Array.Reverse(changedWord);
                return new string(changedWord);
            }

            string reversedWord = Reverse(givenWord);
            Console.WriteLine(reversedWord);
        }
    }
}
