using System;

namespace BonusScoringSystem
{
    class BonusScoringSystem
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());
            int countLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            double highestBonus = 0.0;
            int lectures = 0;


            for (int i = 0; i < studentCount; i++)
            {
                //int bonus = 0;
                int currentStudent = int.Parse(Console.ReadLine());
                double bonus = (double)currentStudent / countLectures * (5 + additionalBonus);

                if (bonus > highestBonus)
                {
                    highestBonus = bonus;
                    lectures = currentStudent;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(highestBonus)}.");
            Console.WriteLine($"The student has attended {lectures} lectures.");
        }
    }
}
