using System;

namespace _2_Division
{
    class Division
    {
        static void Main(string[] args)
        {
            int givenNumber = int.Parse(Console.ReadLine());
            string result = "Not divisible";

            if(givenNumber % 10 == 0)
            {
                result = "The number is divisible by 10";
            }
            else if (givenNumber % 7 == 0)
            {
                result = "The number is divisible by 7";
            }
            else if (givenNumber % 6 == 0)
            {
                result = "The number is divisible by 6";
            }
            else if (givenNumber % 3 == 0)
            {
                result = "The number is divisible by 3";
            }
            else if (givenNumber % 2 == 0)
            {
                result = "The number is divisible by 2";
            }
            else
            {

            }
            Console.WriteLine(result);
        }
    }
}
