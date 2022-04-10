using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            if (names.Count > 0)
            {
                Func<string, int, bool> checker = (a, b) =>
                {
                    int sum = 0;

                    foreach (char item in a)
                    {
                        int num = Convert.ToInt32(item);
                        sum += num;
                    }

                    return sum >= b;
                };

                names = CheckValidity(names, points, checker);

                if (names.Count > 0)
                {
                    Console.WriteLine(names[0]);
                }
            }
        }

        private static List<string> CheckValidity(List<string> names, int points, Func<string, int, bool> checker)
        {
            List<string> list = new List<string>();

            foreach (var name in names)
            {
                if (checker(name, points))
                {
                    list.Add(name);
                }
            }

            return list;
        }
    }
}
