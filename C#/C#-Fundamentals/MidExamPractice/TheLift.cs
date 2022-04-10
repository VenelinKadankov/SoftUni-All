using System;
using System.Linq;

namespace TheLift
{
    class TheLift
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] cabins = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < cabins.Length; i++)
            {
                int current = cabins[i];

                if(current < 4)
                {
                    int diff = 4 - current;
                    //current = 4;

                    if (people >= diff)
                    {
                        people -= diff;
                        cabins[i] = 4;
                    }
                    else
                    {
                        cabins[i] += people;
                        break;
                    }
                }
            }

            if(people > 0 && cabins.Length * 4 == cabins.Aggregate((a, b) => a + b))
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine($"{string.Join(" ", cabins)}");
            }
            else if(people == 0 && cabins.Length * 4 == cabins.Aggregate((a, b) => a + b))
            {
                Console.WriteLine($"{string.Join(" ", cabins)}");
            }
            else
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine($"{string.Join(" ", cabins)}");
            }

        }
    }
}
