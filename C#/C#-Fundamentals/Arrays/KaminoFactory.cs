using System;
using System.Linq;
using System.Linq.Expressions;

namespace KaminoFactory
{
    class KaminoFactory
    {
        static void Main(string[] args)
        {
            int lengthOfSequences = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int counterMax = 1;
            string longestSequence = "";
            int sum = 0;
            int largestSum = 0;
            int longestSum = 0;
            int[] wantedArr = new int[lengthOfSequences];
            int index = 0;
            int wantedIndex = 0;

            while (command != "Clone them!")
            {
                int[] arr = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                index++;

                sum = arr.Aggregate(0, (x, y) => x + y);

                if (sum > largestSum)
                {
                    largestSum = sum;
                }
                //Console.WriteLine(sum);
                string firstSequence = "";
                string secondSequence = "";
                int firstCounter = 1;
                int secondCounter = 1;

                for (int i = 0; i < lengthOfSequences - 1; i++)
                {
                    int element = arr[i];
                    int nextElement = arr[i + 1];


                    if (element == nextElement && firstSequence == "" && secondSequence == "")
                    {
                        firstSequence = element + " " + nextElement;
                        firstCounter++;
                    }
                    else if (element == nextElement && secondSequence == "")
                    {
                        firstSequence += " " + nextElement;
                    }
                    else if (element == nextElement && firstSequence != "")
                    {
                        secondSequence += " " + element;
                        secondCounter++;
                    }
                    else if (element != nextElement && firstSequence.Length >= secondSequence.Length && firstSequence.Length > 0)
                    {
                        secondSequence = "" + nextElement;
                    }
                    else if (element != nextElement && firstSequence.Length < secondSequence.Length)
                    {
                        firstSequence = secondSequence;
                        secondSequence = "" + nextElement;
                    }


                }

                if (firstSequence.Length > longestSequence.Length)
                {
                    longestSequence = firstSequence;
                    wantedArr = arr;
                    longestSum = sum;
                    counterMax = firstCounter;
                    wantedIndex = index;
                }

                command = Console.ReadLine();
            }


            Console.WriteLine($"Best DNA sample {index} with sum: {longestSum}.");
            Console.WriteLine($"{string.Join(" ", wantedArr)}");
        }
    }
}
