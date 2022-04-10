
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

                while (true)
                {

                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:F2} lv.");
        }
    }
}
