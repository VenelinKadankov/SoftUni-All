using System;

namespace RefactoringPrimeChecker
{
    class Refactoring
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            for (int i = 2; i <= endOfRange; i++)
            {
                int num = i;
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    int delimiter = j;

                    if (num % delimiter == 0)
                    {
                        isPrime = false;

                    }
                }
                Console.WriteLine($"{num} -> {isPrime.ToString().ToLower()}");
            }
        }
    }
}
