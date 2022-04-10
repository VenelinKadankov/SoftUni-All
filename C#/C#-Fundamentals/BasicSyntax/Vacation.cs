using System;

namespace Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());
            string typeVisitor = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double finalPrice = 0;
            double pricePerNight = 0;

            if (typeVisitor == "Students")
            {
                switch (dayOfWeek)
                {
                    case "Friday": 
                        pricePerNight = 8.45; break;
                    case "Saturday":
                        pricePerNight = 9.80; break;
                    case "Sunday":
                        pricePerNight = 10.46; break;
                    default: break;
                }

                finalPrice = countPeople * pricePerNight;

                if(countPeople >= 30)
                {
                    finalPrice *= 0.85;
                }
            } 
            else if (typeVisitor == "Business")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerNight = 10.90; break;
                    case "Saturday":
                        pricePerNight = 15.60; break;
                    case "Sunday":
                        pricePerNight = 16; break;
                    default: break;
                }


                finalPrice = countPeople * pricePerNight;

                if (countPeople >= 100)
                {
                    finalPrice -= 10 * pricePerNight;
                }
            }
            else
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerNight = 15; break;
                    case "Saturday":
                        pricePerNight = 20; break;
                    case "Sunday":
                        pricePerNight = 22.50; break;
                    default: break;
                }


                finalPrice = countPeople * pricePerNight;

                if (countPeople >= 10 && countPeople <= 20)
                {
                    finalPrice *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {finalPrice:F2}");
        }
    }
}
