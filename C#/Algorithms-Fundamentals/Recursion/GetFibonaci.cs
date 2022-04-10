using System;
using System.Numerics;

namespace GetFibonaci
{
    class GetFibonaci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FibonaciRec(n));
        }

        private static int FibonaciRec(int n)
        {

            if (n <= 1)
            {
                return n = 1;
            }

            return FibonaciRec(n - 1) + FibonaciRec(n - 2);
        }
    }
}
