using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace Kamino
{
    class Kamino
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int[] wantedArr = new int[length];
            int biggestSum = 0, wantedIndex = int.MaxValue, counter = 0;
            int longestSequence = 0;
            int earliestIndexSequence = int.MaxValue;
            int lastEarliestIndex = int.MaxValue;


            while (command != "Clone them!")
            {
                int[] arr = command
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                counter++;

                int currentSequence = 0, indexArray = 0, indexSequence = 0, arraySum = 0, firstSequence = 0, secondSequence = 0;

                if (arr.Aggregate(0, (x, y) => x + y) == 1)
                {
                    indexSequence = Array.IndexOf(arr, 1);
                    firstSequence = 1;
                    currentSequence = 1;
                }

                int checker = 0;

                for (int i = 0; i < length - 1; i++)
                {

                    int element = Math.Abs(arr[i]);
                    int nextElement = arr[i + 1];


                    if (element != 0 && nextElement != 0)
                    {
                        checker++;

                        if (element == nextElement && firstSequence == 0 && secondSequence == 0)
                        {
                            firstSequence = element + nextElement;
                            indexSequence = i;
                        }
                        else if (element == nextElement && secondSequence == 0)
                        {
                            firstSequence += nextElement;
                        }
                        else if (element == nextElement && firstSequence != 0)
                        {
                            secondSequence += element;
                        }
                        else if (element != nextElement && firstSequence >= secondSequence && firstSequence != 0)
                        {
                            secondSequence = nextElement;
                            indexSequence = i;
                        }
                        else if (element != nextElement && firstSequence < secondSequence)
                        {
                            firstSequence = secondSequence;
                            secondSequence = nextElement;
                        }
                    }

                    if (checker == 0 && arr.Aggregate(0, (x, y) => x + y) > 0)
                    {
                        firstSequence = 0;
                        secondSequence = 0;
                        indexArray = i;
                        indexSequence = Array.IndexOf(arr, 1);
                    }

                }
                ////////////////////////////////////////////////////////////
                 //  4
                //   0!1!0!0
               //    0!1!0!1
                //   Clone them!
                /////////////////////////////////////


                if (indexSequence < earliestIndexSequence)
                {
                    if (earliestIndexSequence == int.MaxValue)
                    {
                        earliestIndexSequence = indexSequence;
                    }
                    else
                    {
                        earliestIndexSequence = lastEarliestIndex;
                    }
                    //earliestIndexSequence = lastEarliestIndex;

                    if (indexSequence < lastEarliestIndex)
                    {
                        lastEarliestIndex = indexSequence;
                    }

                }
                ////////////////////////////////////////////////////////////
                currentSequence = firstSequence;
                indexArray = counter;
                arraySum = arr.Aggregate(0, (x, y) => x + y);

                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    wantedArr = arr;
                    wantedIndex = indexArray;
                    if (arraySum > biggestSum)
                    {
                        biggestSum = arraySum;
                    }
                }
                else if (currentSequence == longestSequence)
                {

                    if (earliestIndexSequence > lastEarliestIndex)
                    {
                        wantedArr = arr;
                        wantedIndex = indexArray;
                    }
                    else if (lastEarliestIndex <= earliestIndexSequence)
                    {
                        arraySum = arr.Aggregate(0, (x, y) => x + y);

                        if (arraySum > biggestSum)
                        {
                            wantedArr = arr;
                            wantedIndex = indexArray;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            int finalSum = wantedArr.Aggregate(0, (x, y) => x + y);
            Console.WriteLine($"Best DNA sample {wantedIndex} with sum: {finalSum}.");
            Console.WriteLine($"{string.Join(" ", wantedArr)}");
        }
    }
}
