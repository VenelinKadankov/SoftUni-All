using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCount
{
    class WordCount
    {
        static void Main(string[] args)

        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] words = File.ReadAllText("../../../words.txt").Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }
            }

            string[] delimiters = new string[] { "-", " ", "?", "!", ".", "," };
            string[] text = File.ReadAllText("../../../input.txt").Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in text)
            {
                if (wordsCount.ContainsKey(word.ToLower()))
                {
                    wordsCount[word.ToLower()]++;
                }
            }

            wordsCount = wordsCount.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, a => a.Value);
            StringBuilder sb = new StringBuilder();

            foreach (var item in wordsCount)
            {
                string line = $"{item.Key} - {item.Value}";
                sb.AppendLine(line);

            }

            File.WriteAllText("../../../output.txt", sb.ToString());

        }
    }
}
