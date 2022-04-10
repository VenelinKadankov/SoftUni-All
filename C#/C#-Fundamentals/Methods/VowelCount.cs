using System;

namespace VowelCount
{
    class VowelCount
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine().ToLower();

            int counter = VowelCounter(line);
            Console.WriteLine(counter);
        }

        private static int VowelCounter(string line)
        {
            char[] letters = line.ToCharArray();
            int counter = 0;

            foreach (var item in letters)
            {
                if (item == 'a' || item == 'e' || item == 'u' || item == 'i' || item == 'o' 
                    || item == 'A' || item == 'E' || item == 'U' || item == 'I' || item == 'O')
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
