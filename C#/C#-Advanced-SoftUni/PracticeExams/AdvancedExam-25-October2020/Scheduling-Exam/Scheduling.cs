using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Scheduling
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int target = int.Parse(Console.ReadLine());

            int length = threads.Count;

            for (int i = 0; i < length; i++)
            {
                int taskValue = tasks.Peek();
                int threadValue = threads.Peek();

                if (threadValue >= taskValue)
                {
                    tasks.Pop();
                }

                if (taskValue == target)
                {
                    Console.WriteLine($"Thread with value {threadValue} killed task {taskValue}");
                    break;
                }

                threads.Dequeue();

            }

            if (threads.Count > 0)
            {
                Console.WriteLine(string.Join(" ", threads));
            }
        }
    }
}