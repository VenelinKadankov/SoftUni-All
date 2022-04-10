using System;
using System.Text;

namespace TopNumber
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int endNum = int.Parse(Console.ReadLine());

            FindMasterNumber(endNum);
        }

        public static void FindMasterNumber(int end)
        {
    
            for (int i = 1; i <= end; i++)
            {
                if(IsDivisibleBy8(i) && HasEnoughDigits(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool IsDivisibleBy8(int num)
        {
            bool isDivisible = false;
            int sum = 0;

           while(num > 0)
            {
                int currentNum = num % 10;
                num /= 10;
                sum += currentNum;
            }

            if (sum % 8 == 0)
            {
                isDivisible = true;
            }

            return isDivisible;
        }

        public static bool HasEnoughDigits(int num)
        {
            int counter = 0;
            bool isEnough = false;

            while (num > 0)
            {
                int current = num % 10;
                num /= 10;

                if(current % 2 != 0)
                {
                    counter++;
                }
            }

            if(counter > 0)
            {
                isEnough = true;
            }

            return isEnough;
        }
    }
}
