using System;

namespace KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                Action<string> print = a => Console.WriteLine($"Sir {a}");
                print(name);
            }

        }

    }
}
