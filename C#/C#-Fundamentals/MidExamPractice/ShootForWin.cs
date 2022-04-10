using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShootForTheWin
{
    class ShootForWin
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> indexesOfShot = new List<int>(targets.Length);
            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                int index = int.Parse(command);
                int shot = 0;

                if (index >= 0 && index < targets.Length)
                {

                    if (!indexesOfShot.Contains(index))
                    {
                        shot = targets[index];
                        targets[index] = -1;
                        indexesOfShot.Add(index);

                        for (int i = 0; i < targets.Length; i++)
                        {

                            if (!indexesOfShot.Contains(i))
                            {
                                if (targets[i] > shot)
                                {
                                    targets[i] -= shot;
                                }
                                else
                                {
                                    targets[i] += shot;
                                }

                            }                           

                        }

                    }

                }    

                command = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {indexesOfShot.Count} -> {string.Join(" ", targets)}");
        }


    }
}
