using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTeams
{
    class SchoolTeams
    {

        static void Main(string[] args)
        {
            string[] girls = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string[] boys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var girlsComb = new string[3];
            var girlsList = new List<string[]>();
            CreateComb(0, 0, girls, girlsComb, girlsList);

            var boysComb = new string[2];
            var boysList = new List<string[]>();
            CreateComb(0, 0, boys, boysComb, boysList);

            foreach (var item in girlsList)
            {

                foreach (var team in boysList)
                {
                    Console.WriteLine($"{string.Join(", ", item)}, {string.Join(", ", team)}");
                }

            }
        }

        private static void CreateComb(int elementsIndex, int combIndex, string[] elements, string[] comb, List<string[]> kidsList)
        {
            if (combIndex >= comb.Length)
            {
                kidsList.Add(comb.ToArray());
                return;
            }

            for (int i = elementsIndex; i < elements.Length; i++)
            {
                comb[combIndex] = elements[i];
                CreateComb(i + 1, combIndex + 1, elements, comb, kidsList);
            }
        }
    }
}
