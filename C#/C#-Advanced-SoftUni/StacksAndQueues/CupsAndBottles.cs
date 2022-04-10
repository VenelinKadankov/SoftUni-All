using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Dequeue();
                int currentBottle = bottles.Pop();

                if (currentCup == currentBottle)
                {
                    continue;
                }
                else if (currentCup > currentBottle)
                {
                    while (currentCup > 0)
                    {
                        currentCup -= currentBottle;

                        if (currentCup <= 0)
                        {
                            break;
                        }

                        if (bottles.Count == 0)
                        {
                            break;
                        }
                        currentBottle = bottles.Pop();

                        if (currentBottle > currentCup)
                        {
                            wastedWater += currentBottle - currentCup;

                        }
                    }
                }
                else
                {
                    wastedWater += currentBottle - currentCup;
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
