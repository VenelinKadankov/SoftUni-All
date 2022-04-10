using System;
using System.Linq;

namespace CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> findSmallest = FindSmallest;
            int num = findSmallest(numbers);

            Console.WriteLine(num);
        }

        private static int FindSmallest(int[] arg)
        {
            return arg.Min();
        }
    }
}
