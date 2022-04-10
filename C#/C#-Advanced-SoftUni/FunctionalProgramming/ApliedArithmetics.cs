using System;
using System.Linq;

namespace ApliedArithmetics
{
    class ApliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> add = a => a.Select(b => b + 1).ToArray();
            Func<int[], int[]> subtract = a => a.Select(b => b - 1).ToArray();
            Func<int[], int[]> multiply = a => a.Select(b => b * 2).ToArray();
            Action<int[]> printer = PrinterArray;

            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "print":
                        printer(numbers);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }


        }

        private static void PrinterArray(int[] obj)
        {
            Console.WriteLine(string.Join(" ", obj));
        }
    }
}
