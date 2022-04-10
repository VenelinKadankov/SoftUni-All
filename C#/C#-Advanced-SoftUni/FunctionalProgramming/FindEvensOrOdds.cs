using System;

namespace FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            string[] borders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int lowerBorder = int.Parse(borders[0]);
            int upperBorder = int.Parse(borders[1]);
            string type = Console.ReadLine();


            Func<int, bool> conditionDelegate = CheckCondition(type, lowerBorder);
            Action<int> printer = PrintResult;

            for (int i = lowerBorder; i <= upperBorder; i++)
            {
                if (conditionDelegate(i))
                {
                    printer(i);
                }

            }

        }

        private static void PrintResult(int obj)
        {
            Console.Write(obj + " ");
        }

        private static Func<int, bool> CheckCondition(string type, int i)
        {
            switch (type)
            {
                case "odd": return i => i % 2 != 0;
                case "even": return a => a % 2 == 0;

                default:
                    return null;
                    break;
            }
        }
    }
}
