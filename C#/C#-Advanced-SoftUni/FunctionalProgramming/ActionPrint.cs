using System;

namespace ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in words)
            {
                Action<string> word = Print;
                word(item);
            }


        }

        public static void Print(string word)
        {
             Console.WriteLine(word);
        }
    }
}
