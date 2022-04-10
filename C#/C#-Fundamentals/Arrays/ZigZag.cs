using System;
using System.Linq;
using System.Linq.Expressions;

namespace ZigZagArrays
{
    class ZigZag
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] firstArr = new int[lines];
            int[] secondArr = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                string currentNums = Console.ReadLine();
                int[] nums = currentNums
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if(i % 2 == 0)
                {
                    firstArr[i] = nums[0];
                    secondArr[i] = nums[1];
                }
                else
                {
                    firstArr[i] = nums[1];
                    secondArr[i] = nums[0];
                }
            }

            Console.WriteLine(string.Join(' ', firstArr));
            Console.WriteLine(string.Join(' ', secondArr));
        }
    }
}
