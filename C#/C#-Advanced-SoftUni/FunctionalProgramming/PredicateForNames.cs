using System;

namespace PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> comparator = a => a.Length <= n;
            Action<string> printer = PrinterNames;

            foreach (var item in names)
            {
                if (comparator(item))
                {
                    printer(item);
                }
            }
        }

        private static void PrinterNames(string obj)
        {
            Console.WriteLine(obj);
        }
    }
}
