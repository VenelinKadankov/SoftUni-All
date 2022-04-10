using System;
using System.Numerics;

namespace FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            long num1 = long.Parse(Console.ReadLine());
            long num2 = long.Parse(Console.ReadLine());

            BigInteger firstSum = CalculateFactorial(num1);
            BigInteger secondSum = CalculateFactorial(num2);

            decimal result = (decimal)firstSum / (decimal)secondSum;

            Console.WriteLine($"{result:F2}");
        }

        public static BigInteger CalculateFactorial(BigInteger num)
        {
            BigInteger sum = 1;

            for (int i = 1; i <= num; i++)
            {
                sum *= i;
            }

            return sum;
        }
    }
}
