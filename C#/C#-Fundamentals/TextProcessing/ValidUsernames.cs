using System;

namespace ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            bool isCorrectSymbol = false;

            for (int i = 0; i < userNames.Length; i++)
            {
                for (int j = 0; j < userNames[i].Length; j++)
                {
                    //char symbol = userNames[i][j];
                    if ((char.IsDigit(userNames[i][j]) 
                        || char.IsLetter(userNames[i][j]) 
                        || userNames[i][j] == '-' 
                        || userNames[i][j] == '_') 
                        && (userNames[i].Length > 2 && userNames[i].Length < 17))
                    {
                        isCorrectSymbol = true;
                    }
                    else
                    {
                        isCorrectSymbol = false;
                        break;
                    }
                }

                if (isCorrectSymbol)
                {
                    Console.WriteLine(userNames[i]);
                }
            }
        }
    }
}
