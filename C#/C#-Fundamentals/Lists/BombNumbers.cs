
using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombAndPower = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bomb = bombAndPower[0], power = bombAndPower[1];
            List<int> ocurances = numbers.Where(a => a == bomb).ToList();

            for (int i = 0; i < ocurances.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] == bomb)
                    {
                        if (j + power < numbers.Count && j - power >= 0)
                        {
                            numbers.RemoveRange(j - power, power * 2 + 1);
                        }
                        else if (j + power >= numbers.Count || j - power <= 0)
                        {
                            int range = power;
                            if (j + power >= numbers.Count && j - power < 0)
                            {
                                range = numbers.Count - j - 1;
                                power = j;
                                numbers.RemoveRange(0, power);
                                numbers.RemoveRange(0, range + 1);  ///////////////

                            }
                            else if (j - power < 0)
                            {
                                range = j;
                                numbers.RemoveRange(0, range);
                                numbers.RemoveRange(0, power + 1);

                            } 
                            else if (j + power >= numbers.Count)
                            {
                                range = numbers.Count - j - 1;
                                numbers.RemoveRange(j - power, power);
                                numbers.RemoveRange(j - power, range + 1);

                            }

                        }

                        break;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
            //Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
