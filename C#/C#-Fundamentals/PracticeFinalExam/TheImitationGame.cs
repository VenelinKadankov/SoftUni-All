using System;

namespace TheImitationGame
{
    class TheImitationGame
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command?.ToLower() != "decode")
            {
                string[] tokens = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                if (action?.ToLower() == "move")
                {
                    int lengthMoved = int.Parse(tokens[1]);
                    string moved = message.Substring(0, lengthMoved);
                    message = message.Replace(moved, "");
                    message += moved;

                }
                else if (action?.ToLower() == "insert")
                {
                    int index = int.Parse(tokens[1]);
                    string value = tokens[2];

                    message = message.Insert(index, value);
                }
                else if (action?.ToLower() == "changeall")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];
                    message = message.Replace(substring, replacement);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
