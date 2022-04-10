using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int payment = int.Parse(Console.ReadLine());
            int counter = 0;
            int lockLeft = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Peek();
                int currentLock = locks.Peek();

                if (bullet > currentLock)
                {
                    counter++;
                    Console.WriteLine("Ping!");

                    if (counter % sizeBarrel == 0 && bullets.Count > 1)
                    {
                        Console.WriteLine("Reloading!");
                    }

                    if (bullets.Count == 0)
                    {
                        lockLeft = currentLock;
                        break;
                    }

                    bullet = bullets.Pop();

                }
                else
                {
                    bullets.Pop();
                    locks.Dequeue();
                    counter++;
                    Console.WriteLine("Bang!");

                    if (counter % sizeBarrel == 0 && bullets.Count >= 1)
                    {
                        Console.WriteLine("Reloading!");
                    }

                }

            }

            payment -= counter * priceBullet;
            if (bullets.Count >= 0 && locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${payment}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            
        }
    }
}
