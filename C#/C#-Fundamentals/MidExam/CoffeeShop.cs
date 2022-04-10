using System;

namespace MidExam
{
    class CoffeeShop
    {
        static void Main(string[] args)
        {
            int countOrders = int.Parse(Console.ReadLine());
            double totalPrice = 0.0;

            for (int i = 0; i < countOrders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double priceOrder = (days * capsulesCount) * pricePerCapsule;
                totalPrice += priceOrder;

                Console.WriteLine($"The price for the coffee is: ${priceOrder:F2}");
            }

            Console.WriteLine($"Total: ${ totalPrice:F2}");
        }
    }
}
