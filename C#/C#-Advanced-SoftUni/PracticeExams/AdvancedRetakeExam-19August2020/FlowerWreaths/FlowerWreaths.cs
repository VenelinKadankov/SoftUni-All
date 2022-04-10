using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class FlowerWreaths
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int storedFlowers = 0;
            int length = Math.Min(lilies.Count, roses.Count);
            int wreaths = 0;

            for (int i = 0; i < length; i++)
            {
                int lily = lilies.Pop();
                int rose = roses.Dequeue();
                int sum = lily + rose;

                if (sum > 15)
                {
                    while (sum > 15)
                    {
                        lily -= 2;

                        if (rose + lily == 15)
                        {
                            wreaths++;
                            break;
                        }
                        else if (rose + lily < 15)
                        {
                            storedFlowers += rose + lily;
                            break;
                        }

                        if (lily <= 0)
                        {
                            break;
                        }
                    }

                }
                else if (sum < 15)
                {
                    storedFlowers += lily + rose;
                }
                else
                {
                    wreaths++;
                }
            }

            int wreathsFromStoredFlowers = storedFlowers / 15;
            wreaths += wreathsFromStoredFlowers;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
