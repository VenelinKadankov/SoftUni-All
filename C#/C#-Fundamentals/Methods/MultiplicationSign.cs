using System;

namespace MultiplicationSign
{
    class MultiplicationSign
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int[] nums = { num1, num2, num3 };

            int negativeCounter = 0;

            for (int i = 0; i < 3; i++)
            {
                string sign = PositiveNegativeChecker(nums[i]);

                if(sign == "negative")
                {
                    negativeCounter++;
                }
            }

            if(num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else if (negativeCounter % 2 != 0)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }

        public static string PositiveNegativeChecker(int num)
        {
            string result = "";

            if (num < 0)
            {
                result = "negative";
            }
            else if (num > 0)
            {
                result = "positive";
            }

            return result;
        }
    }
}
