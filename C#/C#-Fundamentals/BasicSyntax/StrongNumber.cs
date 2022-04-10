using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace StrongNumber
{
    class StrongNumber
    {
        static void Main(string[] args)
        {
            string givenNumber = Console.ReadLine();
            int ourNumber = int.Parse(givenNumber);
            int totalSum = 0;

            char[] numbersArray = givenNumber.ToCharArray();

            for (int i = 0; i < numbersArray.Length; i++)
            {
                char currentNum = numbersArray[i];
                var num = Char.GetNumericValue(currentNum);

                int factorialNumber = 1;


                for (int j = 1; j <= num; j++)
                {
                    if (j >= 1)
                    {
                        factorialNumber *= j;
                    }
                }


                totalSum += factorialNumber;
               // Console.WriteLine(totalSum);
            }

            if(totalSum == ourNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
