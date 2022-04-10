using System;

namespace Padawan_Equipment
{
    class PadawanEquipment
    {
        static void Main(string[] args)
        {
            double totalMoney = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceLightSaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double lightSabersNeeded = Math.Ceiling(1.1 * students);
            double freeBelts = students / 6;
            double moneyNeeded = priceBelt * (students - Math.Floor(freeBelts)) + priceRobe * students + priceLightSaber * lightSabersNeeded;

            if (moneyNeeded <= totalMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:F2}lv.");
            }
            else
            {
                double difference = moneyNeeded - totalMoney;
                Console.WriteLine($"Ivan Cho will need {difference:F2}lv more.");
            }

        }
    }
}
