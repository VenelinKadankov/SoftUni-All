using System;

namespace SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            int timeNeeded = 0;
            int allForHour = first + second + third;

            if (people % allForHour == 0)
            {
                timeNeeded = people / allForHour;
            }
            else
            {
                timeNeeded = people / allForHour + 1;
            }

            int numberOfFours = timeNeeded / 4;


            Console.WriteLine($"Time needed: {timeNeeded + numberOfFours}h.");
        }
    }
}
