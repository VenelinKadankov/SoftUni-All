using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;


namespace Numbers
{
    class Numbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double average = (double)numbers.Aggregate((a, b) => a + b) / numbers.Length;
            List<int> higherNumbers = numbers.Where(a => a > average).ToList();
            List<int> result = new List<int>(higherNumbers.Count);

            if (higherNumbers.Count > 0)
            {
                higherNumbers.Sort((a, b) => b - a);



                int counter = 0;

                for (int i = 0; i < higherNumbers.Count; i++)
                {
                    result.Add(higherNumbers[i]);
                    counter++;

                    if (counter >= 5)
                    {
                        break;
                    }

                }

            }

            //Console.WriteLine(average);
            if (result.Count > 0)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
