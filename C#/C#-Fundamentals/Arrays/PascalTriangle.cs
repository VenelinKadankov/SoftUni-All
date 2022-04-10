using System;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            long[] lastLine = new long[num];
            //long[] currentLine = new long[num];
            lastLine[0] = 1;

            for (long i = 0; i < num; i++)
            {
                long[] currentLine = new long[num];
                currentLine[0] = 1;
                lastLine[0] = 1;

                if (i != 0)
                {
                    for (int k = 0; k < num; k++)
                    {
                        if (k != 0)
                        {
                            currentLine[k] = lastLine[k - 1] + lastLine[k];
                        }

                    }

                    for (int j = 0; j < num; j++)
                    {
                        lastLine[j] = currentLine[j];
                    }


                }

                string lineToPrint = string.Join(" ", currentLine);
                int lastRealNumber = lineToPrint.LastIndexOf('1');
                string result = lineToPrint.Substring(0, lastRealNumber + 1);
                Console.WriteLine(result);

            }
        }
    }
}
