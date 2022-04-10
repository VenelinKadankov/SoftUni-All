using System;

namespace ActivationKEys
{
    class ActivationKeys
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string rawKey = input;
            string command = Console.ReadLine();

            while (command?.ToLower() != "generate")
            {
                string[] tokens = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                if (action?.ToLower() == "contains")
                {
                    string substring = tokens[1];

                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"{input} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (action?.ToLower() == "flip")
                {
                    string toWhat = tokens[1];
                    int start = int.Parse(tokens[2]);
                    int end = int.Parse(tokens[3]);
                    string old = input.Substring(start, (end - start));
                    string changed = string.Empty;

                    if (toWhat?.ToLower() == "lower")
                    {
                        changed = old.ToLower();
                    }
                    else
                    {
                        changed = old.ToUpper();
                    }

                    input = input.Replace(old, changed);
                    Console.WriteLine(input);
                }
                else if (action?.ToLower() == "slice")
                {
                    int start = int.Parse(tokens[1]);
                    int end = int.Parse(tokens[2]);
                    input = input.Remove(start, (end - start));

                    Console.WriteLine(input);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
