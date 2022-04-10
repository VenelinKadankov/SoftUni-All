using System;
using System.Collections.Generic;

namespace CruncherAgain
{
    class CruncherAgain
    {
        public static Dictionary<int, List<string>> byLength;
        public static Dictionary<string, int> occurances;
        public static List<string> combinations;
        public static string wanted;
        public static string[] words;

        static void Main(string[] args)
        {
            words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            wanted = Console.ReadLine();
            combinations = new List<string>();

            foreach (var item in words)
            {
                var key = item.Length;

                if (byLength.ContainsKey(key))
                {
                    byLength[key].Add(item);
                }
                else
                {
                    byLength.Add(key, new List<string>());
                }

                if (occurances.ContainsKey(item))
                {
                    occurances[item]++;
                }
                else
                {
                    occurances.Add(item, 1);
                }
            }


            GenerateComb(0, wanted.Length);
        }

        private static void GenerateComb(int elementIndex, int length)
        {
            if (length == 0)
            {
                if (string.Join("", combinations) == wanted)
                {
                    Console.WriteLine(string.Join("", combinations));
                }
                return;
            }

            for (int i = elementIndex; i < words.Length; i++)
            {
                var word = words[i];

                if (IsMatch(word, wanted))
                {

                }
            }
        }

        private static bool IsMatch(string word, string wanted)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != wanted[i]) 
                {
                    return false;
                }
            }

            return true;
        }
    }
}
