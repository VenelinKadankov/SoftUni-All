using System;
using System.Collections.Generic;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();
            string command = Console.ReadLine();

            while (command?.ToLower() != "buy")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string prod = tokens[0];
                double price = double.Parse(tokens[1]), quantity = double.Parse(tokens[2]);

                if (products.ContainsKey(prod))
                {
                    if (products[prod][0] != price)
                    {
                        products[prod][0] = price;
                    }

                    products[prod][1] += quantity;
                }
                else
                {
                    products.Add(prod, new List<double>());
                    products[prod].Add(price);
                    products[prod].Add(quantity);
                }

                command = Console.ReadLine();
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):F2}");
            }
        }
    }
}
