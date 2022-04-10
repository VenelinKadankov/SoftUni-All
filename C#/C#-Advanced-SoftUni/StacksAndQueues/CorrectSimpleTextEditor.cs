using System;
using System.Collections.Generic;
using System.Linq;

namespace СимплеТеьтЕдитор
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int action = int.Parse(command[0]);

                if (action == 1)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(command[1]);
                    }
                    else
                    {
                        string toAdd = stack.Peek() + command[1];
                        stack.Push(toAdd);
                    }
                }
                else if (action == 2)
                {
                    int n = int.Parse(command[1]);
                    string lastString = stack.Peek();
                    string leftString = lastString.Substring(0, lastString.Length - n);
                    stack.Push(leftString);
                }
                else if (action == 3)
                {
                    int n = int.Parse(command[1]);
                    Console.WriteLine(stack.Peek()[n - 1]);
                }
                else if (action == 4)
                {
                    stack.Pop();
                }

            }


        }
    }
}