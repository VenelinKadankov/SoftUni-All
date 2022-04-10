using System;
using System.Linq;

namespace MaxSequenceOfEqual
{
    class MaxSequence
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string firstSequence = "";
            string secondSequence = "";


            for (int i = 0; i < arr.Length - 1; i++)
            {
                int element = arr[i];
                int nextElement = arr[i + 1];



                if (element == nextElement && firstSequence == "" && secondSequence == "")
                {
                    firstSequence = element + " " + nextElement;
                }
                else if (element == nextElement && secondSequence == "")
                {
                    firstSequence += " " + nextElement;
                }
                else if (element == nextElement && firstSequence != "")
                {
                    secondSequence += " " + element;
                }
                else if (element != nextElement && firstSequence.Length >= secondSequence.Length && firstSequence.Length != 0)
                {
                    secondSequence = "" + nextElement;
                } else if (element != nextElement && firstSequence.Length < secondSequence.Length)
                {
                    firstSequence = secondSequence;
                    secondSequence = "" + nextElement;
                }

                
            }

            Console.WriteLine(firstSequence);
        }
    }
}
