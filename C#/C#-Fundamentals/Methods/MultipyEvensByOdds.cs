using System;

namespace MathOperations
{
    class MultipyEvensByOdds
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));
            string number = $"{num}";
            int[] numsArr = new int[number.Length];

            for (int i = 0; i < number.Length; i++)
            {
                int currentNum = num % 10;
                num /= 10;
                numsArr[i] = currentNum;
            }

            Console.WriteLine(GetMultipleOfEvenAndOdds(GetSumOfEvenDigits(numsArr), GetSumOfOddDigits(numsArr)));

        }

        public static int GetSumOfEvenDigits(int[] arr)
        {
            int evenSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] % 2 == 0)
                {
                    evenSum += arr[i];
                }
            }

            return evenSum;
        }

        public static int GetSumOfOddDigits(int[] arr)
        {
            int oddSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    oddSum += arr[i];
                }
            }

            return oddSum;
        }

        public static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            int sum = evenSum * oddSum;

            return sum;
        }
    }
}
