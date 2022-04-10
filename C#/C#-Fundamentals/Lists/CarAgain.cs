using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAgain
{
    class CarAgain
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

            double leftSum = 0;
            double rightSum = 0;

            for (int i = 0; i < input.Count / 2; i++)
            {
                int num = input[i];
                leftSum += num;

                if (num == 0)
                {
                    leftSum *= 0.8;
                }

            }

            for (int i = input.Count - 1; i > input.Count / 2 + 1; i--)
            {
                int num = input[i];
                rightSum += num;

                if(num == 0)
                {
                    rightSum *= 0.8;
                }
            }

            if(leftSum < rightSum)
            {
                Console.WriteLine($"The winner is left with total time: {leftSum:F1}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightSum:F1}");
            }
        }
    }
}
