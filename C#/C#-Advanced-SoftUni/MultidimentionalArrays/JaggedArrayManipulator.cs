using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            double[][] jaggedArr = new double[length][];

            for (int i = 0; i < length; i++)
            {
                jaggedArr[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int i = 0; i < length - 1; i++)
            {
                if (jaggedArr[i].Length == jaggedArr[i + 1].Length)
                {
                    jaggedArr[i] = jaggedArr[i].Select(a => a *= 2).ToArray();
                    jaggedArr[i + 1] = jaggedArr[i + 1].Select(a => a *= 2).ToArray();
                }
                else
                {
                    jaggedArr[i] = jaggedArr[i].Select(a => a /= 2.0).ToArray();
                    jaggedArr[i + 1] = jaggedArr[i + 1].Select(a => a /= 2.0).ToArray();
                }
            }

            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (tokens[0]?.ToUpper() != "END")
            {
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row >= 0 && col >= 0 && row < jaggedArr.Length && col < jaggedArr[row].Length)
                {
                    if (tokens[0]?.ToUpper() == "ADD")
                    {
                        jaggedArr[row][col] += value;
                    }
                    else if (tokens[0]?.ToUpper() == "SUBTRACT")
                    {
                        jaggedArr[row][col] -= value;
                    }
                }

                tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (double[] arr in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
