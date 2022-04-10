using System;

namespace FirstProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = Console.ReadLine();

            while (command?.ToUpper() != "FINISH")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                if (action?.ToUpper() == "REPLACE")
                {
                    string current = tokens[1];
                    string newChar = tokens[2];

                    text = text.Replace(current, newChar);
                    Console.WriteLine(text);
                }
                else if (action?.ToUpper() == "CUT")
                {
                    int start = int.Parse(tokens[1]);
                    int end = int.Parse(tokens[2]);

                    if (start >= 0 && start < text.Length && end >= 0 && end < text.Length)
                    {
                        text = text.Remove(start, end - start + 1);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }

                }
                else if (action?.ToUpper() == "MAKE")
                {
                    string format = tokens[1];

                    if (format?.ToUpper() == "UPPER")
                    {
                        text = text.ToUpper();
                    }
                    else if (format?.ToUpper() == "LOWER")
                    {
                        text = text.ToLower();
                    }

                    Console.WriteLine(text);

                }
                else if (action?.ToUpper() == "CHECK")
                {
                    string substring = tokens[1];

                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");

                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }

                }
                else if (action?.ToUpper() == "SUM")
                {
                    int start = int.Parse(tokens[1]);
                    int end = int.Parse(tokens[2]);

                    if (start >= 0 && start < text.Length && end >= 0 && end < text.Length)
                    {
                        string substring = text.Substring(start, end - start + 1);
                        int sum = 0;

                        foreach (char item in substring)
                        {
                            int points = Convert.ToInt32(item);
                            sum += points;
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }

                }

                command = Console.ReadLine();
            }

            //Console.WriteLine(text);
        }
    }
}
