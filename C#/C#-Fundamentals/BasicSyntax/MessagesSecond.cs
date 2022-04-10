using System;

namespace Mo05Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSymbols = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 0; i < numberOfSymbols; i++)
            {
                string input = (Console.ReadLine());

                if (input == "0")
                {
                    message += " ";
                }
                else
                {
                    int numberOfDigits = input.Length;
                    int mainDigit = int.Parse(input[0].ToString());
                    int offset = (mainDigit - 2) * 3;
                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset += 1;
                    }
                    int letterIndex = offset + numberOfDigits - 1;

                    //letterIndex+ 97 > asci code

                    message += Convert.ToChar(letterIndex + 97);
                }
            }
            Console.WriteLine(message);
        }
    }
}
