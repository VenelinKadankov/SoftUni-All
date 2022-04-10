using System;
using System.Text;

namespace NxNMatrix
{
    class NxNMatrix
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintMatrix(num);
        }

        private static void PrintMatrix(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                StringBuilder line = new StringBuilder();

                //int[] line = new int[num];
                for (int j = 0; j < num; j++)
                {
                    //line[j] = num;
                    line.Append(num + " ");
                }

               // Console.WriteLine(string.Join(" ", line));
                Console.WriteLine(line);
            }
        }
    }
}
