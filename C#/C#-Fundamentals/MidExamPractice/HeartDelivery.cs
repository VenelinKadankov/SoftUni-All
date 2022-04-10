using System;
using System.Linq;

namespace HeartDelivery
{
    class HeartDelivery
    {
        static void Main(string[] args)
        {
            int[] neighbourhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int cupidIndex = 0;
            string command = Console.ReadLine();

            while (command != "Love!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int jumpIndex = int.Parse(tokens[1]);

                cupidIndex += jumpIndex;

                if(cupidIndex >= neighbourhood.Length)
                {
                    cupidIndex = 0;
                }

                if (neighbourhood[cupidIndex] == 0)
                {
                    Console.WriteLine($"Place {cupidIndex} already had Valentine's day.");
                }
                else if(neighbourhood[cupidIndex] > 0)
                {
                    neighbourhood[cupidIndex] -= 2;

                    if (neighbourhood[cupidIndex] == 0)
                    {
                        Console.WriteLine($"Place {cupidIndex} has Valentine's day.");
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {cupidIndex}.");

            int result = neighbourhood.Aggregate((a, b) => a + b);

            int counter = 0;

            foreach (var item in neighbourhood)
            {
                if(item != 0)
                {
                    counter++;
                }
            }

            if (result > 0)
            {
                Console.WriteLine($"Cupid has failed {counter} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }
        }
    }
}
