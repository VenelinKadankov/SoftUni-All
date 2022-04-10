using System;
using System.Linq;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var stack = new MyCustomStack<int>();

            while (command?.ToUpper() != "END")
            {
                string action = string.Empty;

                if (command.Contains("Push"))
                {
                    action = "Push";
                }
                else
                {
                    action = "Pop";
                }

                if (action == "Pop")
                {
                    stack.Pop();
                }
                else
                {
                    int[] elements = command.Substring(command.IndexOf(" "))
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    stack.Push(elements);
                }


                command = Console.ReadLine();
            }

            ;

            if (stack.Count > 0)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }

                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }


        }
    }
}
