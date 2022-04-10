using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxAndMinElement
{
    class MaxAndMinElement
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (line.Length > 1)
                {
                    stack.Push(line[1]);
                }
                else if (line[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (line[0] == 3)
                {

                    if (stack.Count > 0)
                    {
                        int num = stack.ToArray().Max();
                        Console.WriteLine(num);
                    }
                }
                else if (line[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        int num = stack.ToArray().Min();
                        Console.WriteLine(num);
                    }

                }
            }
            if (stack.Count > 0)
            {
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
