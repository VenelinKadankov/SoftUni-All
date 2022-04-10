using System;
using System.Linq;
using System.Text;

namespace TreasureFinder
{
    class TreasureFinder
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            StringBuilder res = new StringBuilder();

            while (command != "find")
            {

                for (int i = 0; i < command.Length; i++)
                {
                    int current = Convert.ToInt32(command[i]);

                    int numToUse = i % (key.Length);
                    int result = current - key[numToUse];
                    char character = Convert.ToChar(result);
                    res.Append(character);


                }

                string text = res.ToString();
                int indexStart = text.IndexOf('&');
                int indexStart2 = text.LastIndexOf('&');
                int treasureLength = indexStart2 - indexStart - 1;
                int indexCoor1 = text.IndexOf('<');
                int indexCoor2 = text.IndexOf('>');
                int coorLength = indexCoor2 - indexCoor1 - 1;
                string treasure = text.Substring(indexStart + 1, treasureLength);
                string coordinates = text.Substring(indexCoor1 + 1, coorLength);

                Console.WriteLine($"Found {treasure} at {coordinates}");

                res.Clear();
                command = Console.ReadLine();
            }
        }
    }
}
