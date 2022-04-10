using System;
using System.Linq;
using System.Numerics;

namespace FromLeftToRight
{
    class FromLeftToRight
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            BigInteger biggerNumber = 0;

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                string[] numbers = line.Split(" ");

                BigInteger firstNum = BigInteger.Parse(numbers[0]);
                BigInteger secondNum = BigInteger.Parse(numbers[1]);
                BigInteger sum = 0;
                string ourLength = "";

                if (firstNum > secondNum)
                {
                    biggerNumber = firstNum;
                    ourLength = numbers[0];
                } else
                {
                    ourLength = numbers[1];
                    biggerNumber = secondNum;
                }

                for (int j = 0; j < ourLength.Length; j++)
                {
                    long lastDigit = (long)biggerNumber % 10;
                    biggerNumber /= 10;
                    sum += lastDigit;
                }

                Console.WriteLine(sum);
            }

        }
    }
}
