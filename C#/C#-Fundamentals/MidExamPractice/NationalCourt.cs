using System;

namespace National_Court
{
    class NationalCourt
    {
        static void Main(string[] args)
        {
            int firstPerHour = int.Parse(Console.ReadLine());
            int secondPerHour = int.Parse(Console.ReadLine());
            int thirdPerHour = int.Parse(Console.ReadLine());
            int totalPerHour = firstPerHour + secondPerHour + thirdPerHour;
            int totalPeople = int.Parse(Console.ReadLine());

            int hourCounter = 0;

            while (totalPeople > 0)
            {
                totalPeople -= totalPerHour;
                hourCounter++;

                if (hourCounter % 4 == 0)
                {
                    hourCounter++;
                }
            }

            Console.WriteLine($"Time needed: { hourCounter}h.");
        }
    }
}
