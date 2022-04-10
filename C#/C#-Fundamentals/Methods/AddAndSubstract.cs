using System;

namespace AddAndSubstract
{
    class AddAndSubstract
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = SubstractNumbers(AddNumbers(num1, num2), num3);
            Console.WriteLine(result);
        }

        public static int AddNumbers(int num1, int num2)
        {
            int sum = num1 + num2;
            return sum;
        }

        static int SubstractNumbers(int num1, int num2)
        {
            int result = num1 - num2;
            return result;
        }
    }
}
