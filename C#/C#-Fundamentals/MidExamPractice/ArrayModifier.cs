using System;
using System.Linq;

namespace ArrayModifier
{
    class ArrayModifier
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];
                int index1 = 0, index2 = 0;

                if (tokens.Length > 1)
                {
                    index1 = int.Parse(tokens[1]);
                    index2 = int.Parse(tokens[2]);
                }

                int first = numbers[index1], second = numbers[index2];

                switch (action)
                {
                    case "swap":
                        numbers[index1] = second;
                        numbers[index2] = first;
                        break;
                    case "multiply":
                        int result = first * second;
                        numbers[index1] = result;
                        break;
                    case "decrease":
                        numbers = numbers.Select(a => a - 1).ToArray();
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
