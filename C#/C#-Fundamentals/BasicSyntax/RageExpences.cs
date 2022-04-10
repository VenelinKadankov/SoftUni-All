using System;

namespace RageExpences
{
    class RageExpences
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            float priceHeadset = float.Parse(Console.ReadLine());
            float priceMouse = float.Parse(Console.ReadLine());
            float priceKeyboard = float.Parse(Console.ReadLine());
            float priceDisplay = float.Parse(Console.ReadLine());

            double headsets = lostGames / 2;
            double brokenHeadsets = Math.Floor(headsets);
            double mouses = lostGames / 3;
            double brokenMouses = Math.Floor(mouses);
            double keyboards = lostGames / 6;
            double brokenKeyboards = Math.Floor(keyboards);
            double displays = lostGames / 12;
            double brokenDisplays = Math.Floor(displays);

            double totalExpences = brokenHeadsets * priceHeadset +
                brokenMouses * priceMouse +
                brokenKeyboards * priceKeyboard +
                brokenDisplays * priceDisplay;

            Console.WriteLine($"Rage expenses: {totalExpences:F2} lv.");

        }
    }
}
