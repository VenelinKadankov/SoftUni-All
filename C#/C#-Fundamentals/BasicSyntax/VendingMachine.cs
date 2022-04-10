using System;

namespace Vending_Machine
{
    class VendingMachine
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            double acumulatedMoney = 0;

            while(comand != "Start")
            {
                double insertedCoin = double.Parse(comand);

                switch (insertedCoin)
                {
                    case 2: 
                        acumulatedMoney += 2;
                        break;
                    case 1:  
                        acumulatedMoney += 1;
                        break;
                    case 0.5:
                        acumulatedMoney += 0.5;
                        break;
                    case 0.2: 
                        acumulatedMoney += 0.2;
                        break;
                    case 0.1:
                        acumulatedMoney += 0.1;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {insertedCoin}");
                        break;

                }
               

                comand = Console.ReadLine();
            }

            string product = Console.ReadLine();
            while (product != "End")
            {
                double priceProduct = 0;

                switch (product)
                {

                    case "Nuts":
                        priceProduct = 2;
                        break;
                    case "Water":
                        priceProduct = 0.7;
                        break;
                    case "Crisps":
                        priceProduct = 1.5;
                        break;
                    case "Soda":
                        priceProduct = 0.8;
                        break;
                    case "Coke":
                        priceProduct = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                if (priceProduct > acumulatedMoney)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else if(priceProduct <= acumulatedMoney && 
                    (product == "Nuts" || product == "Water" || product == "Crisps" || product == "Soda" || product == "Coke"))
                {

                    Console.WriteLine($"Purchased {product.ToLower()}");
                    acumulatedMoney -= priceProduct;
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {acumulatedMoney:F2}");
        }
    }
}
