using System;

namespace SecretChat
{
    class SecretChat
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command?.ToLower() != "reveal")
            {
                string[] tokens = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                if (action?.ToLower() == "insertspace")
                {
                    int index = int.Parse(tokens[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (action?.ToLower() == "reverse")
                {
                    string substring = tokens[1];
                    char[] strToRvr = substring.ToCharArray();
                    Array.Reverse(strToRvr);
                    string reversed = string.Join("", strToRvr);

                    if (message.Contains(substring))
                    {
                        message = message.Remove(message.IndexOf(substring), substring.Length);
                        message += reversed;
                        Console.WriteLine(message);
                    }
                    else 
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (action?.ToLower() == "changeall")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];
                    message = message.Replace(substring, replacement);
                    Console.WriteLine(message);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
