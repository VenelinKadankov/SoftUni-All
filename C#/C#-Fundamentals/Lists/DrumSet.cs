using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class DrumSet
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            List<int> initialValues = drumSet.GetRange(0, drumSet.Count);
            bool isOver = false;

            while (command != "Hit it again, Gabsy!")
            {
                int power = int.Parse(command);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    if(drumSet[i] > 0)
                    {
                        drumSet[i] -= power;
                    }

                    if (drumSet[i] <= 0 && initialValues[i] * 3 <= savings)
                    {
                        drumSet[i] = initialValues[i];
                        savings -= initialValues[i] * 3;
                    }

                }

                command = Console.ReadLine();
            }

            drumSet = drumSet.Where(a => a > 0).ToList();
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
