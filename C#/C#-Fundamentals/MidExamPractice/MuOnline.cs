using System;
using System.Linq;

namespace MuOnline
{
    class MuOnline
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int initialHealth = 100;
            int coins = 0;
            int roomCounter = 0;
            bool isDead = false;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] tokens = rooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];
                int power = int.Parse(tokens[1]);
                roomCounter++;

                if (action?.ToLower() == "potion")
                {
                    int preeviousHealth = initialHealth;
                    initialHealth += power;

                    if (initialHealth < 100)
                    {
                        Console.WriteLine($"You healed for {power} hp.");
                        //initialHealth += power;
                    }

                    if (initialHealth > 100)
                    {
                        Console.WriteLine($"You healed for {100 - preeviousHealth} hp.");
                        initialHealth = 100;
                    }


                    Console.WriteLine($"Current health: {initialHealth} hp.");

                }
                else if (action?.ToLower() == "chest")
                {
                    coins += power;
                    Console.WriteLine($"You found {power} bitcoins.");
                }
                else
                {
                    initialHealth -= power;

                    if (initialHealth > 0)
                    {
                        Console.WriteLine($"You slayed {action}.");
                    }
                    else
                    {
                        isDead = true;
                        Console.WriteLine($"You died! Killed by {action}.");
                        Console.WriteLine($"Best room: {roomCounter}");
                        break;
                    }
                }
            }

            if (!isDead)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {coins}");
                Console.WriteLine($"Health: {initialHealth}");
            }
        }
    }
}
