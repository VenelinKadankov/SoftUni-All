using System;
using System.Linq;

namespace TopInteger
{
    class TopInteger
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] resultArr = new int[numbers.Length];


            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                bool isBigger = false;

                for (int j = i + 1; j <  numbers.Length; j++)
                {
                    int comparedNum = numbers[j];

                    if (num > comparedNum)
                    {
                        isBigger = true;
                    }
                    else
                    {
                        isBigger = false;
                        break;
                    }

                }

                if (isBigger || i == numbers.Length - 1)
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
