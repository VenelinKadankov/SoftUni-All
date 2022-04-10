using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousThreat
{
    class AnonymousThreat
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "3:1")
            {
                string action = command[0];
                int startIndex = int.Parse(command[1]), endIndex = int.Parse(command[2]);

                if (startIndex < 0)
                {
                    startIndex = 0;
                }
                if (startIndex >= input.Count)
                {
                    startIndex = input.Count - 1;
                }
                if (endIndex >= input.Count)
                {
                    if (action == "merge")
                    {
                        endIndex = input.Count - 1;
                    }

                }
                if(endIndex < 0)
                {
                    endIndex = 0;
                }

                if (action == "merge")
                {
                    string newElement = string.Empty;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        newElement += input[i];
                    }

                    input.RemoveRange(startIndex, endIndex - startIndex + 1);
                    if (newElement != string.Empty)
                    {
                        input.Insert(startIndex, newElement);
                    }

                }
                else
                {
                    int partitions = endIndex;
                    string ourObject = input[startIndex];
                    List<string> text = new List<string>(ourObject.Length);

                    for (int z = 0; z < ourObject.Length; z++) 
                    {
                        text.Add(ourObject[z].ToString());
                    }

                    int lengthOfParts = text.Count / partitions;
                    List<string> newList = new List<string>(partitions);

                    for (int k = 0; k < partitions - 1; k++)
                    {
                        List<string> line = text.GetRange(0, lengthOfParts).ToList();
                        string element = string.Join("", line);
                        text.RemoveRange(0, lengthOfParts);
                        newList.Add(element);

                    }

                    input.InsertRange(startIndex + 1, newList);
                    input.Insert(startIndex + partitions, string.Join("", text));
                    input.RemoveAt(startIndex);

                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join(' ', input));

        }
    }
}
