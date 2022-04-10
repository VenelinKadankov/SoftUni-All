using System;

namespace Messages
{
    class Messages
    {
        static void Main(string[] args)
        {
            int numberOfArguments = int.Parse(Console.ReadLine());
            string finalWords = "";

            for (int i = 0; i < numberOfArguments; i++)
            {
                string argument = Console.ReadLine();
                int num = int.Parse(argument);
                int mainNum = num % 10;
                int numLength = argument.Length;
                int digitMovement = (mainNum - 2) * 3;

                if (mainNum == 0)
                {
                    finalWords += " ";
                }
                else if (mainNum == 8 || mainNum == 9)
                {
                    digitMovement += 1;
                    finalWords = "" + finalWords + (Convert.ToChar(digitMovement + numLength - 1 + 97));
                }
                else
                {
                    finalWords = "" + finalWords + (Convert.ToChar(digitMovement + numLength - 1 + 97));
                }


            }

            Console.WriteLine(finalWords);
        }
    }
}
