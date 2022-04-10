using System;

namespace ComputerStore
{
    class ComputerStore
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalPrice = 0.0;

            while (command?.ToLower() != "special" && command?.ToLower() != "regular")
            {
                double pricePart = double.Parse(command);

                if (pricePart >= 0)
                {
                    totalPrice += pricePart;
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }

                command = Console.ReadLine();
            }

            double priceWithTaxes = 0.0;
            double taxes = 0.0;

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                priceWithTaxes = 1.2 * totalPrice;
                taxes = priceWithTaxes - totalPrice;

                if (command == "special")
                {
                    priceWithTaxes *= 0.9;
                }

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:F2}$");
                Console.WriteLine($"Taxes: {taxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {priceWithTaxes:F2}$");
            }
        }
    }
}
