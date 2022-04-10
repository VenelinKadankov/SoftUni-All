using System;

namespace CounterStrike
{
    class CounterStrike
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int counterWon = 0;
            bool isLost = false;

            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if (distance > initialEnergy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {counterWon} won battles and {initialEnergy} energy");
                    isLost = true;
                    break;
                }
                else
                {
                    initialEnergy -= distance;
                    counterWon++;
                }

                if (counterWon % 3 == 0)
                {
                    initialEnergy += counterWon;
                }
                command = Console.ReadLine();
            }

            if (!isLost)
            {
                Console.WriteLine($"Won battles: {counterWon}. Energy left: {initialEnergy}");
            }
        }
    }
}
