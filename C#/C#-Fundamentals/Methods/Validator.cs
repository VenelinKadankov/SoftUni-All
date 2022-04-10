using System;

namespace PasswordValidator
{
    class Validator
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isInRange = IsLongEnough(password);
            bool isCorrectSymbols = ExcludesOtherSymbols(password);
            bool isWithDigits = HasEnoughDigits(password);

            if (isInRange && isCorrectSymbols && isWithDigits)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!isInRange)
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!isCorrectSymbols)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!isWithDigits)
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }

        }

        public static bool IsLongEnough(string password)
        {
            int length = password.Length;
            bool isEnough = false;

            if (length >= 6 && length <= 10)
            {
                isEnough = true;
            }
            else
            {
                isEnough = false;
            }

            return isEnough;
        }

        static bool ExcludesOtherSymbols(string password)
        {
            char[] characters = password.ToCharArray();
            bool isCorrectSymbol = false;

            for (int i = 0; i < password.Length; i++)
            {
                int num = (int)characters[i];

                if ((num >= 97 && num <= 122) || (num >= 65 & num <= 90) || (num >= 48 && num <= 57))
                {
                    isCorrectSymbol = true;
                }
                else
                {
                    isCorrectSymbol = false;
                    return isCorrectSymbol;
                }

            }

            return isCorrectSymbol;
        }

        static bool HasEnoughDigits(string password)
        {
            int counter = 0;
            bool isEnough = false;
            char[] characters = password.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                int num = (int)characters[i];

                if (num >= 48 && num <= 57)
                {
                    counter++;
                }
            }

            if (counter >= 2)
            {
                isEnough = true;
            }

            return isEnough;
        }
    }
}
