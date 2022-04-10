using System;
using System.Linq;

namespace MagicSum
{
    class MagicSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                int firstNum = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    int secondNum = arr[j];
                    if (firstNum + secondNum == sum)
                    {
                        Console.WriteLine($"{firstNum} {secondNum}");
                        break;
                    }
                }
            }
        }
    }
}
