using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            List<int> result = new List<int>(number.Length);
            int previousToAdd = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int num = (int)Char.GetNumericValue(number[i]);
                 int sum = num * multiplier;
                //double num = Char.GetNumericValue(number[i]);
                // int sum = (int)num * multiplier;
                sum += previousToAdd;
                int lastDig = sum % 10;
                result.Insert(0, lastDig);
                previousToAdd = sum / 10;

            }

            if (previousToAdd != 0)
            {
                result.Insert(0, previousToAdd);
            }

            int length = result.Count;

            for (int i = 0; i < length; i++)
            {
                if (result[0] == 0 )
                {
                    result.RemoveAt(0);
                }
                else
                {
                    break;
                }

            }

            if (number == "0" || multiplier == 0)
            {
                Console.WriteLine(0);
            }
            else
            Console.WriteLine(string.Join("", result));
        }
    }
}
