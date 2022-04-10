using System;

namespace PasswordReset
{
    class PasswordReset
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            string command = Console.ReadLine();

            while (command?.ToLower() != "done")
            {
                if (command?.ToLower() == "takeodd")
                {
                    string changed = string.Empty;

                    for (int i = 0; i < pass.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            changed += pass[i];
                        }
                    }

                    pass = changed;
                    Console.WriteLine(pass);
                }
                else if (command.Contains("Cut"))
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int index = int.Parse(tokens[1]), length = int.Parse(tokens[2]);
                    if (index >= 0 && index <= pass.Length && index + length <= pass.Length)
                    {

                    }
                    pass = pass.Remove(index, length);
                    Console.WriteLine(pass);

                }
                else if (command.Contains("Substitute"))
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string astion = tokens[0], substring = tokens[1], substitute = tokens[2];

                    if (pass.Contains(substring))
                    {
                        pass = pass.Replace(substring, substitute);
                        Console.WriteLine(pass);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {pass}");
        }
    }
}
