using System;
using System.Reflection.Metadata.Ecma335;

namespace NumberComparer
{
    class FindSmallest
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int smallest = FindSmallestNum(num1, num2, num3);
            Console.WriteLine(smallest);
        }

        private static int FindSmallestNum(int num1, int num2, int num3)
        {
            if (num1 < num2 && num1 < num3)
            {
                return num1;
            } 
            else if (num2 < num1 && num2 <num3)
            {
                return num2; 
            }
            else
            {
                return num3;
            }
        }
    }
}
