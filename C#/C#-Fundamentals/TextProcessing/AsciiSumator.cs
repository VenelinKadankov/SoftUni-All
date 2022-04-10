using System;

namespace AsciiSumator
{
    class AsciiSumator
    {
        static void Main(string[] args)
        {
            char[] firstChar = Console.ReadLine().ToCharArray();
            char[] secondChar = Console.ReadLine().ToCharArray();
            string text = Console.ReadLine();
            int sum = 0;

            int start = Math.Min(Convert.ToInt32(firstChar[0]), Convert.ToInt32(secondChar[0]));
            int end = Math.Max(Convert.ToInt32(firstChar[0]), Convert.ToInt32(secondChar[0]));

            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];
                int num = Convert.ToInt32(current);

                if (start < num && num < end)
                {
                    sum += num;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
