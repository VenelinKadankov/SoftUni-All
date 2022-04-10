using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffect = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> bombCasing = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            SortedDictionary<string, int> readyBombs = new SortedDictionary<string, int>();
            readyBombs.Add("Datura", 0);
            readyBombs.Add("Cherry", 0);
            readyBombs.Add("Smoke Decoy", 0);

            string key = string.Empty;
            bool isFull = false;

            int length = Math.Min(bombEffect.Count, bombCasing.Count);

            while(bombCasing.Count > 0 && bombEffect.Count > 0)
            {
                int bomb = bombEffect.Dequeue();
                int casing = bombCasing.Pop();
                int sum = bomb + casing;

                while (sum != 40 && sum != 60 && sum != 120)
                {
                    casing -= 5;

                    sum = bomb + casing;

                    if (sum <= 0)
                    {
                        break;
                    }
                }

                switch (sum)
                {
                    case 40:
                        key = "Datura";
                        break;
                    case 60:
                        key = "Cherry";
                        break;
                    case 120:
                        key = "Smoke Decoy";
                        break;
                    default:
                        break;
                }

                readyBombs[key]++;

                if (readyBombs.Values.All(b => b >= 3))
                {
                    isFull = true;
                    break;
                }
            }

            if (isFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }

            if (bombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }

            foreach (var bomb in readyBombs)
            {
                Console.WriteLine($"{bomb.Key} Bombs: {bomb.Value}");
            }
        }
    }
}
