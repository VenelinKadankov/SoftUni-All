using System;

namespace RecursiveFactorial
{
    class Factorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RecFac(n));
        }

        private static long RecFac(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * RecFac(n - 1);
        }
    }
}
