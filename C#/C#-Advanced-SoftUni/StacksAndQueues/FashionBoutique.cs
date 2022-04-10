using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            Stack<int> box = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int length = box.Count();
            int capacity = int.Parse(Console.ReadLine());
            int initialCapacity = capacity;
            int counter = 1;

            if (initialCapacity > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    int weight = box.Pop();

                    if (weight < capacity)
                    {
                        capacity -= weight;
                    }
                    else if (weight == capacity)
                    {
                        capacity = initialCapacity;
                        if (box.ToArray().Sum() > 0)
                        {
                            counter++;
                        }

                    }
                    else
                    {
                        capacity = initialCapacity - weight;
                        counter++;
                    }
                }
            }

            if (initialCapacity == 0)
            {
                counter = 0;
            }

            Console.WriteLine(counter);
        }
    }
}
