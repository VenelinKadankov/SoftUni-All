using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Messaging
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] indexes = new int[numbers.Length];
            List<char> resultList = new List<char>();

            string text = Console.ReadLine();
            List<char> characters = new List<char>(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                characters.Add(text[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                int result = 0;
                while (num > 0)
                {
                    int current = num % 10;
                    num /= 10;
                    result += current;
                }

                indexes[i] = result;
            }


            for (int i = 0; i < indexes.Length; i++)
            {
                int newIndex = indexes[i] % text.Length;
                char currentChar = characters[newIndex];
                characters.RemoveAt(newIndex);
                resultList.Add(currentChar);
            }

            Console.WriteLine(string.Join("", resultList));
        }
    }
}
