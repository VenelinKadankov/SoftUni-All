using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int totalOrders = orders.Count;
            int biggest = orders.ToArray().Max();

            for (int i = 0; i < totalOrders; i++)
            {
                int order = orders.Peek();

                if (order <= food)
                {
                    orders.Dequeue();
                    food -= order;
                }
                else
                {
                    break;
                }

            }

            Console.WriteLine(biggest);

            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
