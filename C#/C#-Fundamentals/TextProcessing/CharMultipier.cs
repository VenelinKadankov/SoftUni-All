using System;
using System.Linq;

namespace CharMultiplier
{
    class CharMultipier
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            for (int i = 0; i < Math.Min(words[0].Length, words[1].Length); i++)
            {
                int first = Convert.ToInt32(words[0][i]);
                int second = Convert.ToInt32(words[1][i]);
                int currentSum = first * second;
                sum += currentSum;
            }

            int longerLength = Math.Max(words[0].Length, words[1].Length);
            int leftSum = 0;

            if (words[0].Length == longerLength)
            {
                int diff = words[0].Length - words[1].Length;
                string left = words[0].Substring(longerLength - diff);
                //char[] leftChars = left.ToCharArray();
               // leftSum = leftChars.Select(a => Convert.ToInt32(a)).Sum();
                leftSum = left.ToCharArray().Select(a => Convert.ToInt32(a)).Sum();
            }
            else
            {
                int diff = words[1].Length - words[0].Length;
                string left = words[1].Substring(longerLength - diff);
                //char[] leftChars = left.ToCharArray();
                // leftSum = leftChars.Select(a => Convert.ToInt32(a)).Sum();
                leftSum = left.ToCharArray().Select(a => Convert.ToInt32(a)).Sum();
            }

            sum += leftSum;

            Console.WriteLine(sum);
        }
    }
}
