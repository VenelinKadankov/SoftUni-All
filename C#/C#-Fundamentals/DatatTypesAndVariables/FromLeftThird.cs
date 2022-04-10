using System;


namespace BalancedBrackets
{
    class BalancedBrackets
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            bool isBalanced = true;
            string lastBracket = "";
            string firstBracket = "no";
            bool isRightFirst = false;
            string finalBracket = "";
            int counterLeft = 0;
            int counterRight = 0;

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                string currentBracket = "";

                if ((line == "(" || line == ")") && firstBracket == "no")
                {
                    if (line == "(")
                    {
                        firstBracket = "(";
                        isRightFirst = false;
                    }
                    else
                    {
                        isBalanced = false;
                        isRightFirst = true;
                        break;
                    }
                }

                if (line == "(")
                {
                    currentBracket = "(";
                    counterLeft++;
                }
                else if (line == ")")
                {
                    currentBracket = ")";
                    counterRight++;
                }



                if (lastBracket == currentBracket)
                {
                    isBalanced = false;
                    break;
                }
                else if (line == "(" || line == ")")
                {
                    lastBracket = currentBracket;
                }
            }

            if (!isBalanced && counterLeft != counterRight)
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
                Console.WriteLine("BALANCED");
            }
        }
    }
}




