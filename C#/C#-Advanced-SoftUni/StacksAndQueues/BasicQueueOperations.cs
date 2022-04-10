
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> stack = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int n = commands[0];
            int toPop = commands[1];
            int searched = commands[2];

            for (int i = 0; i < toPop; i++)
            {
                stack.Dequeue();
            }

            if (stack.Contains(searched))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int min = stack.ToArray().Min();
                Console.WriteLine(min);
            }
        }
    }
}
