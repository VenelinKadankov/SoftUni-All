using System;
using System.Collections.Generic;
using System.Text;

namespace LettersCahngeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0.0;
            Dictionary<string, int> lowerAlphabet = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                double currentSum = 0.0;
                char first = input[i][0];
                char last = input[i][input[i].Length - 1];
                StringBuilder num = new StringBuilder();

                for (int j = 1; j < input[i].Length - 1; j++)
                {
                    num.Append(input[i][j]);
                }

                string n = num.ToString();

                double number = 0.0;

                if (Double.TryParse(n, out number))
                {
                    number = double.Parse(n);
                }

                int firstCode = Convert.ToInt32(first);
                int secondCode = Convert.ToInt32(last);
                int position = 0;

                if (firstCode <= 90 && 65 <= firstCode)
                {
                    position = firstCode - 64;
                    currentSum = number / position;
                }
                else if (firstCode <= 122 && 97 <= firstCode)
                {
                    position = firstCode - 96;
                    currentSum = number * position;
                }

                if (secondCode <= 90 && 65 <= secondCode)
                {
                    position = secondCode - 64;
                    currentSum = currentSum - position;
                }
                else if (secondCode <= 122 && 97 <= secondCode)
                {
                    position = secondCode - 96;
                    currentSum = currentSum + position;
                }


                sum += currentSum;
                //Console.WriteLine(currentSum);
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
