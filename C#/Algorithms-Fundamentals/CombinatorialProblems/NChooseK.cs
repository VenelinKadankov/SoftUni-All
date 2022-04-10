using System;

namespace NChoseKPOsitions
{
    class NChooseK
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcPascal(n, k));
        }

        private static int CalcPascal(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return CalcPascal(row - 1, col - 1) + CalcPascal(row - 1, col);
        }
    }
}
