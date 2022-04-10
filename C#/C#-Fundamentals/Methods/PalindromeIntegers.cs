using System;

namespace PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                bool isPalindrome = CheckIfPalindrome(line);

                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                line = Console.ReadLine();
            }

        }

        public static bool CheckIfPalindrome(string line)
        {
            bool isPalindrome = true;
            if (line.Length % 2 == 0)
            {
                for (int i = 0; i < line.Length / 2; i++)
                {
                    if (line[i] == line[line.Length - 1 - i])
                    {
                        isPalindrome = true;
                    }
                    else
                    {
                        isPalindrome = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < (line.Length - 1) / 2; i++)
                {
                    if (line[i] == line[line.Length - 1 - i])
                    {
                        isPalindrome = true;
                    }
                    else
                    {
                        isPalindrome = false;
                        break;
                    }
                }
            }
            return isPalindrome;
        }
    }
}
