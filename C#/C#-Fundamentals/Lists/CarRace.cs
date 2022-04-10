using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class CarRace
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int middleIndex = input.Count / 2;
            int range = input.Count / 2;

            List<int> first = input.GetRange(0, range);
            List<int> second = input.GetRange(middleIndex + 1, range);
            second.Reverse();

           // Console.WriteLine(string.Join(" ", second));

            double firstSpeed = CalculateSpeed(first);
            double secondSpeed = CalculateSpeed(second);

            if (firstSpeed < secondSpeed)
            {
                Console.WriteLine($"The winner is left with total time: {firstSpeed}");
            }
            else if (firstSpeed > secondSpeed)
            {
                Console.WriteLine($"The winner is right with total time: {secondSpeed}");
            }

        }

        public static double CalculateSpeed(List<int> input)
        {
            double result = 0.0;

            for (int i = 0; i < input.Count; i++)
            {
                int num = input[i];

                result += num;

                if (num == 0)
                {
                    result *= 0.8;
                }

            }
            return result;
        }
    }
}
