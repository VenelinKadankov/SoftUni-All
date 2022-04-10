using System;

namespace GamingStore
{
    class GamingStore
    {
        static void Main(string[] args)
        {
            float moneyAvailable = float.Parse(Console.ReadLine());
            double startingMoney = Math.Round(moneyAvailable,2);
            double moneySpent = 0;
            string command = Console.ReadLine();

            while (command != "Game Time")
            {
                double priceGame = 0;
                string wantedGame = command;
                bool gameIsAvailable = false;

                switch (wantedGame)
                {
                    case "OutFall 4":
                        priceGame = 39.99;
                        gameIsAvailable = true;
                        break;
                    case "CS: OG":
                        priceGame = 15.99;
                        gameIsAvailable = true;
                        break;
                    case "Zplinter Zell":
                        priceGame = 19.99;
                        gameIsAvailable = true;
                        break;
                    case "Honored 2":
                        priceGame = 59.99;
                        gameIsAvailable = true;
                        break;
                    case "RoverWatch":
                        priceGame = 29.99;
                        gameIsAvailable = true;
                        break;
                    case "RoverWatch Origins Edition":
                        priceGame = 39.99;
                        gameIsAvailable = true;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if(gameIsAvailable && startingMoney >= priceGame)
                {
                    Console.WriteLine($"Bought {wantedGame}");
                    startingMoney -= priceGame;
                    moneySpent += priceGame;
                } 
                else if (gameIsAvailable && startingMoney < priceGame)
                {
                    Console.WriteLine("Too Expensive");
                }

                if(moneyAvailable <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${moneySpent:F2}. Remaining: ${startingMoney:F2}");

        }
    }
}
