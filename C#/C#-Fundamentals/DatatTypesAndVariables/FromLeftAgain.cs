using System;
using System.Linq;


namespace FromLeftAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());


            for (int i = 0; i < lines; i++)
            {
                
                string line = Console.ReadLine();
                long[] nums = line.Split(" ").Select(long.Parse).ToArray();

                long leftNum = nums[0];
                long rightNum = nums[1];
                long currentNum = 0;
                long sum = 0;

                if (leftNum > rightNum)
                {
                    currentNum = leftNum;
                } 
                else
                {
                    currentNum = rightNum;
                }

                while (currentNum != 0)
                {
                    long lastDigit = currentNum % 10;
                    sum += lastDigit;
                    currentNum /= 10;
                }

                    Console.WriteLine(Math.Abs(sum));

            }
        }
    }
}
