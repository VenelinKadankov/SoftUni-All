using System;
using System.Linq;

namespace ReverseAndExclude
{
    class RevereAndExclude
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divisor = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverser = a => a.Reverse().ToArray();
            Func<int[], int[]> remover = a => a.Where(a => a % divisor != 0).ToArray();
            numbers = reverser(numbers);
            numbers = remover(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
