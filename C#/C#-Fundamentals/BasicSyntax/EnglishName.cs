using System;

namespace EnglishName
{
    class EnglishName
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            int lastDigit = inputNumber % 10;

            Console.WriteLine(lastDigit);
        }
    }
}
