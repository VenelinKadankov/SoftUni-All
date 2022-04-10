using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                string[] parts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0]?.ToLower() == "add")
                {
                    int first = int.Parse(parts[1]);
                    int second = int.Parse(parts[2]);

                    nums.Push(first);
                    nums.Push(second);
                }
                else
                {
                    int toremove = int.Parse(parts[1]);

                    if (nums.Count >= toremove)
                    {
                        for (int i = 0; i < toremove; i++)
                        {
                            nums.Pop();
                        }
                    }
                }

                command = Console.ReadLine();
            }

            int sum = nums.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
