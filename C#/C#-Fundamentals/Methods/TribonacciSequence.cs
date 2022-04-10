using System;

namespace TribonacciSequence
{
    class TribonacciSequence
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] result = CreateSequence(length);

            Console.WriteLine(string.Join(" ", result));
        }

        public static int[] CreateSequence(int length)
        {
            int[] resultArr = new int[length];



                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                    {
                        resultArr[0] = 1;
                    }
                    else if (i == 1)
                    {
                        resultArr[0] = 1;
                        resultArr[1] = 1;
                    }
                    else if (i == 2)
                    {
                        resultArr[0] = 1;
                        resultArr[1] = 1;
                        resultArr[2] = 2;
                    }
                    else
                    {
                        resultArr[i] = resultArr[i - 1] + resultArr[i - 2] + resultArr[i - 3];
                    }

                }
            

            return resultArr;
        }
    }
}
