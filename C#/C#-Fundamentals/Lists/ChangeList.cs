using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (commands[0].ToUpper() != "END")
            {
                switch (commands[0].ToUpper())
                {
                    case "DELETE":

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == int.Parse(commands[1]))
                            {
                                numbers.Remove(int.Parse(commands[1]));
                            }
                        }

                        break;
                    case "INSERT":
                        int num = int.Parse(commands[1]);
                        numbers.Insert(int.Parse(commands[2]), num);
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
